using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Services;
using AutoMapper;
using Domain.Entities.ConfigurationModelsж;
using Domain.Entities.Identity;
using Domain.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Persistence.Services;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private AppUser? _user;

    public AuthenticationService(
        ILoggerManager logger,
        IMapper mapper,
        UserManager<AppUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
        _jwtConfiguration = new JwtConfiguration();
        _configuration.Bind(_jwtConfiguration.Section, _jwtConfiguration);
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="userForRegistration">User for registration.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the result.
    /// </returns>
    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        if (CheckEmailExistsAsync(userForRegistration.Email).Result == true)
        {
            Console.WriteLine("true");
            throw new CheckEmailExistsBadRequest();
        }

        var user = _mapper.Map<AppUser>(userForRegistration);
        var result = await _userManager.CreateAsync(user, userForRegistration.Password);

        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

        return result;
    }

    /// <summary>
    /// Retrieves the user from the database and checks if it exists and if the password matches.
    /// </summary>
    /// <param name="userForAuth">User for authentication.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the result.
    /// If the verification result is false, it registers a message about failed authentication.
    /// </returns>
    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
    {
        /*
            The UserManager<TUser> class provides the FindByNameAsync method to search for a user by username
            and CheckPasswordAsync to check the user's password for compliance with the hashed password from the database. 
         */

        _user = await _userManager.FindByEmailAsync(userForAuth.Email);

        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

        if (!result)
            _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong username or password.");

        return result;
    }

    /// <summary>
    /// Creates a token. It does this by collecting information from private methods
    /// and serializing token parameters.
    /// </summary>
    /// <param name="populateExp">Populate expiry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the token in 'Compact Serialazation Format'.
    /// </returns>
    public async Task<TokenDto> CreateToken(bool populateExp)
    {
        /*
            Generates an update token and expiry date for the logged-in user,
            and also returns both an access token
            and an update token to the caller.
         */
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        var refreshToken = GenerateRefreshToken();

        _user!.RefreshToken = refreshToken;

        if (populateExp)
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

        await _userManager.UpdateAsync(_user);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new TokenDto(accessToken, refreshToken);
    }

    /// <summary>
    /// Refreshes a token.
    /// </summary>
    /// <param name="tokenDto">Token data transfer object.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the token in 'Compact Serialazation Format'.
    /// </returns>
    public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

        var user = await _userManager.FindByNameAsync(principal.Identity!.Name!);

        if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new RefreshTokenBadRequest();

        _user = user;

        return await CreateToken(populateExp: false);
    }

    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the current user.
    /// </returns>
    public async Task<UserDto> GetCurrentUserAsync()
    {
        var email = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

        _user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == email);

        var token = await CreateToken(populateExp: true);

        return new UserDto
        {
            Email = _user!.Email!,
            Username = _user!.UserName!,
            AccessToken = token.AccessToken,
            RefreshToken = token.RefreshToken
        };
    }

    /// <summary>
    /// Gets the user's address.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the user's address.
    /// </returns>
    public async Task<AddressDto> GetUserAddressAsync()
    {
        var email = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

        _user = await _userManager.Users
            .Include(x => x.Address)
            .SingleOrDefaultAsync(x => x.Email == email);

        var addressDto = _mapper.Map<Address, AddressDto>(_user!.Address);

        return addressDto;
    }

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="addressDto">Data transfer object for address.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the updated user.
    /// </returns>
    /// <exception cref="UpdateUserAddressBadRequest">If the update result is not successful.</exception>
    public async Task<AddressDto> UpdateUserAddressAsync(AddressDto addressDto)
    {
        var email = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

        _user = await _userManager.Users
            .Include(x => x.Address)
            .SingleOrDefaultAsync(x => x.Email == email);

        _user!.Address = _mapper.Map<AddressDto, Address>(addressDto);

        var result = await _userManager.UpdateAsync(_user);

        if (!result.Succeeded)
            throw new UpdateUserAddressBadRequest();


        var addressToReturn = _mapper.Map<Address, AddressDto>(_user.Address);

        return addressToReturn;
    }

    /// <summary>
    /// Checks if email exists.
    /// </summary>
    /// <param name="email">A user's email.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<bool> CheckEmailExistsAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) != null;
    }       

    #region private helper methods for CreateToken()

    /// <summary>
    /// Gets the secret key as a byte array with the security algorithm.
    /// </summary>
    /// <returns>
    /// Returns the secret key.
    /// </returns>
    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey!);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    /// <summary>
    /// Creates a list of claims with the username inside and all the roles the user belongs to.
    /// </summary>
    /// <returns>
    /// Returns a list of claims.
    /// </returns>
    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, _user!.Email!)
        };

        var roles = await _userManager.GetRolesAsync(_user);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }


    /// <summary>
    /// Creates an object of the JwtSecurityToken using type with all of the required options.
    /// </summary>
    /// <param name="signingCredentials">Signing credentials.</param>
    /// <param name="claims">Claims.</param>
    /// <returns>
    /// Returns an object of the JwtSecurityToken.
    /// </returns>
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }

    /// <summary>
    /// Generates the refresh token.
    /// </summary>
    /// <returns>
    /// Returns a a cryptographic random number for refresh token.
    /// </returns>
    private string GenerateRefreshToken()
    {
        /*
            The method contains the logic to generate the refresh token.
            We use the RandomNumberGenerator class to generate a cryptographic random number for this purpose.
         */

        var randomNumber = new byte[32];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    /// <summary>
    /// Gets the user principal from the expired access token.
    /// </summary>
    /// <param name="token">Token.</param>
    /// <returns>Returns the ClaimsPrincipal object.</returns>
    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        /*
            The method is used to get the user principal from the expired access token.
            We make use of the ValidateToken method from the JwtSecurityTokenHandler class for this purpose.
            This method validates the token and returns the ClaimsPrincipal object.
         */

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey)),
            ValidateLifetime = true,
            ValidIssuer = _jwtConfiguration.ValidIssuer,
            ValidAudience = _jwtConfiguration.ValidAudience
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        SecurityToken securityToken;

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);


        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }

    #endregion private helper methods for CreateToken()
}


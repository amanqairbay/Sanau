using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.DTOs;
using Application.Services;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Persistence.Services;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    private AppUser? _user;

    public AuthenticationService(
        ILoggerManager logger,
        IMapper mapper,
        UserManager<AppUser> userManager,
        IConfiguration configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
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

        _user = await _userManager.FindByNameAsync(userForAuth.UserName);

        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

        if (!result)
            _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong username or password.");

        return result;
    }

    /// <summary>
    /// Creates a token. It does this by collecting information from private methods
    /// and serializing token parameters.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the token in 'Compact Serialazation Format'.
    /// </returns>
    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["secretKey"];

        var key = Encoding.UTF8.GetBytes(secretKey!);
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
            new Claim(ClaimTypes.Name, _user!.UserName!)
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
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenOptions = new JwtSecurityToken
        (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }

    #endregion private helper methods for CreateToken()
}


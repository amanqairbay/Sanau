using Application.Common.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

/// <summary>
/// Represents an authentication service.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="userForRegistration">User for registration.</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result.
    /// </returns>
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);

    /// <summary>
    /// Retrieves the user from the database and checks if it exists and if the password matches.
    /// </summary>
    /// <param name="userForAuth">User for authentication.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the result.
    /// If the verification result is false, it registers a message about failed authentication.
    /// </returns>
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);

    /// <summary>
    /// Creates a token. It does this by collecting information from private methods
    /// and serializing token parameters.
    /// </summary>
    /// <param name="populateExp">Populate expiry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the token in 'Compact Serialazation Format'.
    /// </returns>
    Task<TokenDto> CreateToken(bool populateExp);

    /// <summary>
    /// Refreshes a token
    /// </summary>
    /// <param name="tokenDto">Token data transfer object.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the token in 'Compact Serialazation Format'.
    /// </returns>
    Task<TokenDto> RefreshToken(TokenDto tokenDto);

    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the current user.
    /// </returns>
    Task<UserDto> GetCurrentUserAsync();

    /// <summary>
    /// Gets the user's address.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the user's address.
    /// </returns>
    Task<AddressDto> GetUserAddressAsync();

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="addressDto">Data transfer object for address.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the updated user.
    /// </returns>
    /// <exception cref="UpdateUserAddressBadRequest">If the update result is not successful.</exception>
    Task<AddressDto> UpdateUserAddressAsync(AddressDto addressDto);

    /// <summary>
    /// Checks if email exists.
    /// </summary>
    /// <param name="email">A user's email.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<bool> CheckEmailExistsAsync(string email);
}

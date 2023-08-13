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
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the token in 'Compact Serialazation Format'.
    /// </returns>
    Task<string> CreateToken();
}

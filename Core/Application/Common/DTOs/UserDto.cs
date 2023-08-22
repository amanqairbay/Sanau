namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for user.
/// </summary>
public record UserDto
{
    /// <summary>
    /// Gets or initializes a user's email.
    /// </summary>
    public string Email { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a username.
    /// </summary>
    public string Username { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a user's access token.
    /// </summary>
    public string AccessToken { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a user's refresh token.
    /// </summary>
    public string RefreshToken { get; init; } = String.Empty;
}
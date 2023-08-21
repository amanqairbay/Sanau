namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for user.
/// </summary>
/// <param name="Email">Email.</param>
/// <param name="Username">Username.</param>
/// <param name="AccessToken">Access token.</param>
/// <param name="RefreshToken">Refresh token.</param>
public record UserDto
{
    public string Email { get; init; }
    public string Username { get; init; }
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
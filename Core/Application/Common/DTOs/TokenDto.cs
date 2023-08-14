namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for token.
/// </summary>
/// <param name="AccessToken">Access token.</param>
/// <param name="RefreshToken">Refresh token.</param>
public record TokenDto(string AccessToken, string RefreshToken);

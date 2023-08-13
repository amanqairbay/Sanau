using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for user authentication.
/// </summary>
public record UserForAuthenticationDto
{
    [Required(ErrorMessage = "User name is required")]
    public string UserName { get; init; } = String.Empty;

    [Required(ErrorMessage = "Password name is required")]
    public string Password { get; init; } = String.Empty;
}
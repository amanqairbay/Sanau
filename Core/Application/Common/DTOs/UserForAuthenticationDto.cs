using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for user authentication.
/// </summary>
public record UserForAuthenticationDto
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; init; } = String.Empty;

    [Required(ErrorMessage = "Password name is required")]
    public string Password { get; init; } = String.Empty;
}
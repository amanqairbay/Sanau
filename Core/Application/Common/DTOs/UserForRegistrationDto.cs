using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for user registration.
/// </summary>
public record UserForRegistrationDto
{
    /// <summary>
    /// Gets or initializes the user's name.
    /// </summary>
    [Required]
    public string UserName { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes the user's email.
    /// </summary>
    /// [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes the user's password.
    /// </summary>
    [Required(ErrorMessage = "Password is required.")]
    [RegularExpression("(?=^.{8,16}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 number non alphanumeric and at least 6 characters.")]
    public string Password { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes the user's roles.
    /// </summary>
    public ICollection<string> Roles { get; init; } = default!;
}
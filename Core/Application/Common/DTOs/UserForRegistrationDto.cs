﻿using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for user registration.
/// </summary>
public record UserForRegistrationDto
{
    /// <summary>
    /// Gets or initializes the user's name.
    /// </summary>
    public string UserName { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes the user's email.
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes the user's password.
    /// </summary>
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes the user's roles.
    /// </summary>
    public ICollection<string> Roles { get; init; } = default!;
}
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a category for creation data transfer object.
/// </summary>
public record CategoryForCreationDto
{
    /// <summary>
    /// Gets or initializes a category name.
    /// </summary>
    [Required(ErrorMessage = "Category name is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or initializes a category description.
    /// </summary>
    [Required(ErrorMessage = "Category description is a required field.")]
    [MaxLength(200, ErrorMessage = "Maximum length for the Description is 200 characters.")]
    public string? Description { get; init; }
}
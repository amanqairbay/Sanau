using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a brand data transfer object for creation.
/// </summary>
public record BrandForCreationDto
{
    /// <summary>
    /// Gets or initializes a brand name.
    /// </summary>
    [Required(ErrorMessage = "Brand name is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or initializes a brand description.
    /// </summary>
    [Required(ErrorMessage = "Brand description is a required field.")]
    [MaxLength(200, ErrorMessage = "Maximum length for the Description is 200 characters.")]
    public string? Description { get; init; }
}
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a product object for creation.
/// </summary>
public record ProductForCreationDto
{
    /// <summary>
    /// Gets or initializes a product name.
    /// </summary>
    [Required(ErrorMessage = "Product name is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
    public string? Name { get; init; }
    
    /// <summary>
    /// Gets or initializes a product price.
    /// </summary>
    [Display(Name = "Price")]
    [Required]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
    public decimal Price { get; init; }
    
    /// <summary>
    /// Gets or initializes a product cadegory identifier.
    /// </summary>
    public Guid CategoryId { get; init; }
}
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

/// <summary>
/// Represents a brand.
/// </summary>
public class Brand : BaseEntity
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [Required(ErrorMessage = "Brand name is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")] 
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [Required(ErrorMessage = "Brand description is a required field.")]
    [MaxLength(200, ErrorMessage = "Maximum length for the Description is 200 characters.")] 
    public string? Description { get; set; }
    
    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    public ICollection<Product>? Products { get; set; }
}
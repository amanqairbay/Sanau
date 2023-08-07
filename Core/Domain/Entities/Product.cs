using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

/// <summary>
/// Represents a product.
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [Required(ErrorMessage = "Product name is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")] 
    public string? Name { get; set; }
    
    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value></value>
    [Required(ErrorMessage = "Price is a required field.")]
    [Column(TypeName = "decimal(38,2)")]
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the products image url.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the brand identifier..
    /// </summary>
    [ForeignKey(nameof(Brand))]
    public Guid BrandId { get; set; }

    /// <summary>
    /// Gets or sets the brand.
    /// </summary>
    public Brand? Brand { get; set; }

    /// <summary>
    /// Gets or sets the category identifier..
    /// </summary>
    [ForeignKey(nameof(Category))]
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    public Category? Category { get; set; }
}
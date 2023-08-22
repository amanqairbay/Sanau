using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for a customer basket item.
/// </summary>
public record BasketItemDto
{
    /// <summary>
    /// Gets or initializes a basket item identifier.
    /// </summary>
    [Required]
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or initializes a product name.
    /// </summary>
    [Required]
    public string ProductName { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a product price.
    /// </summary>
    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; init; }

    /// <summary>
    /// Gets or initializes a basket item quantity.
    /// </summary>
    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; init; }

    /// <summary>
    /// Gets or initializes a product image url.
    /// </summary>
    [Required]
    public string ImageUrl { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a product brand.
    /// </summary>
    [Required]
    public string Brand { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a product category.
    /// </summary>
    [Required]
    public string Category { get; init; } = String.Empty;
}
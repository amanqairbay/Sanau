namespace Domain.Entities;

/// <summary>
/// Represents a basket item.
/// </summary>
public class BasketItem
{
    /// <summary>
    /// Gets or sets a basket item identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a product price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets a basket item quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets a product image url.
    /// </summary>
    public string ImageUrl { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a product brand.
    /// </summary>
    public string Brand { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a product category.
    /// </summary>
    public string Category { get; set; } = String.Empty;
}
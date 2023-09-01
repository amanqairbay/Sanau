namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for order item.
/// </summary>
public record OrderItemDto
{
    /// <summary>
    /// Gets or initializes a product identifier.
    /// </summary>
    public Guid ProductId { get; init; }

    /// <summary>
    /// Gets or initializes a product name.
    /// </summary>
    public string ProductName { get; init; }

    /// <summary>
    /// Gets or initializes a product image url.
    /// </summary>
    public string ImageUrl { get; init; }

    /// <summary>
    /// Gets or initializes a price.
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Gets or initializes quantity.
    /// </summary>
    public int Quantity { get; init; }
}
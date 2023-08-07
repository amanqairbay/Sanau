namespace Application.Common.DTOs;

/// <summary>
/// Represents a product data transfer object.
/// </summary>
public record ProductDto
{
    /// <summary>
    /// Gets or initializes a product identifier.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or initializes a product name.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Gets or initializes a product price.
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Gets or initializes a product image url.
    /// </summary>
    public string? ImageUrl { get; init; }
}
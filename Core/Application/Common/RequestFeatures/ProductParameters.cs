namespace Application.Common.RequestFeatures;

/// <summary>
/// Represents a product parameters.
/// </summary>
public class ProductParameters : RequestParameters
{
    /// <summary>
    /// Gets or sets a product minimum price.
    /// </summary>
    public decimal MinPrice { get; set; } = decimal.Zero;

    /// <summary>
    /// Gets or sets a product maximum price.
    /// </summary>
    public decimal MaxPrice { get; set; } = decimal.MaxValue;

    /// <summary>
    /// Gets a product valid price range.
    /// </summary>
    public bool ValidPriceRange => MaxPrice > MinPrice;

    /// <summary>
    /// Gets or sets a search term.
    /// </summary>
    public string? SearchTerm { get; set; }
}
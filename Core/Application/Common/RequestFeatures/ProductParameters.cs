namespace Application.Common.RequestFeatures;

/// <summary>
/// Represents a product parameters.
/// </summary>
public class ProductParameters : RequestParameters
{
    /// <summary>
    /// Gets or sets a product minimum price.
    /// </summary>
    public decimal MinPrice { get; set; } = 0;

    /// <summary>
    /// Gets or sets a product maximum price.
    /// </summary>
    public decimal MaxPrice { get; set; } = 10000000;

    /// <summary>
    /// Gets a product valid price range.
    /// </summary>
    public bool ValidPriceRange => MaxPrice > MinPrice;
}
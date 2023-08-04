namespace Application.Common.RequestFeatures;

/// <summary>
/// Represents a product parameters.
/// </summary>
public class ProductParameters : RequestParameters
{
    #region properties
    /// <summary>
    /// Gets or sets a product minimum price.
    /// </summary>
    public decimal MinPrice { get; set; } = 0; //TODO: to fix

    /// <summary>
    /// Gets or sets a product maximum price.
    /// </summary>
    public decimal MaxPrice { get; set; } = 100_000_000_000M;

    /// <summary>
    /// Gets a product valid price range.
    /// </summary>
    public bool ValidPriceRange => MaxPrice > MinPrice;

    /// <summary>
    /// Gets or sets a search term.
    /// </summary>
    public string? SearchTerm { get; set; }

    #endregion properties

    #region constructor
    public ProductParameters() => OrderBy = "name";

    #endregion constructor
}
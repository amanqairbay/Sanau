using Domain.Common;

namespace Domain.Entities.OrderAggregate;

/// <summary>
/// Represents an ordered product item.
/// </summary>
public class ProductItemOrdered : BaseEntity
{
    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a product image url.
    /// </summary>
    public string ImageUrl { get; set; } = String.Empty;

    #region constructors

    public ProductItemOrdered() { }

    public ProductItemOrdered(Guid id, string productName, string imageUrl)
    {
        Id = id;
        ProductName = productName;
        ImageUrl = imageUrl;
    }

    #endregion constructors
}
using Domain.Common;

namespace Domain.Entities.OrderAggregate;

/// <summary>
/// Represents a delivery method.
/// </summary>
public class DeliveryMethod : BaseEntity
{
    /// <summary>
    /// Gets or sets a short name.
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// Gets or sets delivery time.
    /// </summary>
    public string DeliveryTime { get; set; }

    /// <summary>
    /// Gets or sets a description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    public decimal Price { get; set; }
}
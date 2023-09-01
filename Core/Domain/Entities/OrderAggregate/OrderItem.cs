using Domain.Common;

namespace Domain.Entities.OrderAggregate;

/// <summary>
/// Represents an order item.
/// </summary>
public class OrderItem : BaseEntity
{
    /// <summary>
    /// Gets or sets an ordered product item.
    /// </summary>
    public ProductItemOrdered ItemOrdered { get; set; }

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets a quantity.
    /// </summary>
    public int Quantity { get; set; }

    #region constructor

    public OrderItem()
    {

    }

    public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity)
    {
        //Id = Guid.NewGuid();
        ItemOrdered = itemOrdered;
        Price = price;
        Quantity = quantity;
    }

    #endregion constructor
}
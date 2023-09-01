using Domain.Common;

namespace Domain.Entities.OrderAggregate;

/// <summary>
/// Represents an order.
/// </summary>
public class Order : BaseEntity
{
    /// <summary>
    /// Gets or sets a buyer email.
    /// </summary>
    public string BuyerEmail { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets an order date.
    /// </summary>
    public DateTime OrderDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets ship to address.
    /// </summary>
    public Address ShipToAddress { get; set; }

    /// <summary>
    /// Gets or sets a delivery method identifier.
    /// </summary>
    public Guid DeliveryMethodId { get; set; }

    /// <summary>
    /// Gets or sets a delivery method.
    /// </summary>
    public DeliveryMethod DeliveryMethod { get; set; }

    /// <summary>
    /// Gets or sets an order times.
    /// </summary>
    public IReadOnlyList<OrderItem> OrderItems { get; set; }

    /// <summary>
    /// Gets or sets a sbtotal.
    /// </summary>
    public decimal Subtotal { get; set; }

    /// <summary>
    /// Gets or sets a status.
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Gets or sets payment itent identifier.
    /// </summary>
    public string PaymentItentId { get; set; } = String.Empty;

    #region constructors

    public Order()
    {

    }

    public Order(
        IReadOnlyList<OrderItem> orderItems,
        string buyerEmail,
        Address shipToAddress,
        Guid deliveryMethodId,
        decimal subtotal)
    {
        OrderItems = orderItems;
        BuyerEmail = buyerEmail;
        ShipToAddress = shipToAddress;
        DeliveryMethodId = deliveryMethodId;
        Subtotal = subtotal;
    }

    #endregion constructors

    /// <summary>
    /// Gets total price.
    /// </summary>
    public decimal GetTotal()
    {
        return Subtotal + DeliveryMethod.Price;
    }
}

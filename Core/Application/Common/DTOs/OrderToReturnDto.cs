using ShipToAddress = Domain.Entities.OrderAggregate.Address;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for order to return.
/// </summary>
public record OrderToReturnDto
{
    /// <summary>
    /// Gets or initializes an order identifier.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or initializes a bueyr's email.
    /// </summary>
    public string BuyerEmail { get; init; }

    /// <summary>
    /// Gets or initializes an order date.
    /// </summary>
    public DateTime OrderDate { get; init; }

    /// <summary>
    /// Gets or initializes a shipping address.
    /// </summary>
    public ShipToAddress ShipToAddress { get; init; }

    /// <summary>
    /// Gets or initializes a delivery method.
    /// </summary>
    public string DeliveryMethod { get; init; }

    /// <summary>
    /// Gets or initializes a shipping price.
    /// </summary>
    public decimal ShippingPrice { get; init; }

    /// <summary>
    /// Gets or initializes an order items.
    /// </summary>
    public IReadOnlyList<OrderItemDto> OrderItems { get; init; }

    /// <summary>
    /// Gets or initializes a sub total.
    /// </summary>
    public decimal SubTotal { get; init; }

    /// <summary>
    /// Gets or initializes a total.
    /// </summary>
    public decimal Total { get; init; }

    /// <summary>
    /// Gets or initializes a status.
    /// </summary>
    public string Status { get; init; }
}
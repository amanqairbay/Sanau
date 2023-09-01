using System.Runtime.Serialization;

namespace Domain.Entities.OrderAggregate;

/// <summary>
/// Represents an order status.
/// </summary>
public enum OrderStatus
{
    [EnumMember(Value = "Pending")]
    Pending,

    [EnumMember(Value = "Payment Received")]
    PaymentReceived,

    [EnumMember(Value = "Pending")]
    PaymentFailed
}
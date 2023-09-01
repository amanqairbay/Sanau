namespace Application.Common.Exceptions;

/// <summary>
/// Represents a not found exception for order.
/// </summary>
public sealed class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(Guid orderId) : base($"The order with id: {orderId} doesn't exist in the database.")
    {
    }
}
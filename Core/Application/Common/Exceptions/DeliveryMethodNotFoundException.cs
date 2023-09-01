namespace Application.Common.Exceptions;

/// <summary>
/// Represents a not found exception for delivery method.
/// </summary>
public sealed class DeliveryMethodNotFoundException : NotFoundException
{
    public DeliveryMethodNotFoundException(Guid deliveryMethodId) : base($"The product with id: {deliveryMethodId} doesn't exist in the database.")
    {
    }
}
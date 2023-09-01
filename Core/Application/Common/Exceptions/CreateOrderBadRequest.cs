namespace Application.Common.Exceptions;

/// <summary>
/// Represents a bad request exception for create order.
/// </summary>
public sealed class CreateOrderBadRequest : BadRequestException
{
    public CreateOrderBadRequest() : base("Problem creating order.")
    {
    }
}
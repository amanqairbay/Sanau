namespace Application.Common.Exceptions;

/// <summary>
/// Represents a not found exception for basket.
/// </summary>
public sealed class BasketNotFoundException : NotFoundException
{
    public BasketNotFoundException(string basketId) : base($"The basket with id: {basketId} doesn't exist.")
    {
    }
}
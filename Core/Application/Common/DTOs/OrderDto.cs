namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for order.
/// </summary>
/// <param name="basketId">A customer basket's identifier.</param>
/// <param name="deliveryMethodId">A delivery method's identifier.</param>
/// <param name="ShipToAddress">Shipping address.</param>
public record OrderDto(string basketId, Guid deliveryMethodId, AddressDto ShipToAddress);
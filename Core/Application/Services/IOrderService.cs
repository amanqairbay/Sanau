using Application.Common.DTOs;
using Domain.Entities.OrderAggregate;

namespace Application.Services;

/// <summary>
/// Represents an order service.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Creates an order.
    /// </summary>
    /// <param name="orderDto">Data transfer object for order.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the created order.
    /// </returns>
    /// <exception cref="CreateOrderBadRequest">Bad Request exception for order creating.</exception>
    Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto);

    /// <summary>
    /// Gets user's orders. 
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the user's orders.
    /// </returns>
    Task<IReadOnlyList<OrderToReturnDto>> GetOrdersForUserAsync();

    /// <summary>
    /// Gets order by identifier.
    /// </summary>
    /// <param name="orderId">Order identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the order.
    /// </returns>
    /// <exception cref="OrderNotFoundException">Not found exception for order.</exception>
    Task<OrderToReturnDto?> GetOrderByIdAsync(Guid orderId);

    /// <summary>
    /// Gets delivery methods.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the delivery methods.
    /// </returns>
    Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync();
}
using Domain.Entities.OrderAggregate;

namespace Application.Repositories;

/// <summary>
/// Represents an order repository.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Creates an order.
    /// </summary>
    /// <param name="order">Order entity.</param>
    public void CreateOrder(Order order);

    /// <summary>
    /// Gets user's orders.
    /// </summary>
    /// <param name="buyerEmail">Buyer's email.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// A task that represents the asynchronous operation.
    /// The task result contains the orders.
    /// </returns>
    Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string? buyerEmail, bool trackChanges);

    /// <summary>
    /// Gets orders.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the orders.
    /// </returns>
    Task<IEnumerable<Order>> GetOrdersAsync(bool trackChanges);

    /// <summary>
    /// Gets an order by identifier.
    /// </summary>
    /// <param name="orderId">Order identifier.</param>
    /// <param name="buyerEmail">Buyer's email.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the order.
    /// </returns>
    Task<Order?> GetOrderByIdAsync(Guid orderId, string? buyerEmail, bool trackChanges);
}
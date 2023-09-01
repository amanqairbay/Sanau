using Application.Repositories;
using Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

/// <summary>
/// Represents an order repository.
/// </summary>
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    #region constructors

    public OrderRepository(DataContext context) : base(context)
    {
    }

    #endregion constructors

    /// <summary>
    /// Creates an order.
    /// </summary>
    /// <param name="order">Order entity.</param>
    public void CreateOrder(Order order) => Create(order);

    /// <summary>
    /// Gets user's orders.
    /// </summary>
    /// <param name="buyerEmail">Buyer's email.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// A task that represents the asynchronous operation.
    /// The task result contains the orders.
    /// </returns>
    public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string? buyerEmail, bool trackChanges) =>
        await FindByCondition(o => o.BuyerEmail.Equals(buyerEmail), trackChanges)
        .Include(o => o.DeliveryMethod)
        .Include(o => o.OrderItems)
        .ToListAsync();

    /// <summary>
    /// Gets orders.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the orders.
    /// </returns>
    public async Task<IEnumerable<Order>> GetOrdersAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .Include(o => o.DeliveryMethod)
        .Include(o => o.OrderItems)
        .ToListAsync();

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
    public async Task<Order?> GetOrderByIdAsync(Guid orderId, string? buyerEmail, bool trackChanges) =>
        await FindByCondition(o => o.Id.Equals(orderId) && o.BuyerEmail.Equals(buyerEmail), trackChanges)
        .Include(o => o.DeliveryMethod)
        .Include(o => o.OrderItems)
        .SingleOrDefaultAsync();
}
using Application.Repositories;
using Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

/// <summary>
/// Represents a delivery method repository.
/// </summary>
public class DeliveryMethodRepository : BaseRepository<DeliveryMethod>, IDeliveryMethodRepository
{
    public DeliveryMethodRepository(DataContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets delivery methods.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the delivery methods.
    /// </returns>
    public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .ToListAsync();

    /// <summary>
    /// Gets a delivery method by identifier.
    /// </summary>
    /// <param name="deliveryMethodId">Delivery method identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the delivery method.
    /// </returns>
    public async Task<DeliveryMethod?> GetByIdAsync(Guid deliveryMethodId, bool trackChanges) =>
        await FindByCondition(dm => dm.Id.Equals(deliveryMethodId), trackChanges)
        .SingleOrDefaultAsync();
}
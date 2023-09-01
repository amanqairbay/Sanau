using Domain.Entities.OrderAggregate;

namespace Application.Repositories;

/// <summary>
/// Represents a delivery method repository.
/// </summary>
public interface IDeliveryMethodRepository
{
    /// <summary>
    /// Gets delivery methods.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the delivery methods.
    /// </returns>
    Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync(bool trackChanges);

    Task<DeliveryMethod?> GetByIdAsync(Guid id, bool trackChanges);
}

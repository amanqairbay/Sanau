using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services;

namespace Persistence.Services;

/// <summary>
/// Represents a delivery method service.
/// </summary>
public sealed class DeliveryMethodService : IDeliveryMethodService
{
    private readonly IRepositoryManager _repository;

    public DeliveryMethodService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Checks if delivery method exists.
    /// </summary>
    /// <param name="deliveryMethodId">Delivery method identifier.</param>
    /// <returns></returns>
    /// <exception cref="NotFoundException">Throw if the delivery method doesn't exist in the database.</exception>
    public async Task CheckDeliveryMethodExists(Guid deliveryMethodId)
    {
        var deliveryMethod = await _repository.DeliveryMethodRepository.GetByIdAsync(deliveryMethodId, trackChanges: false);

        if (deliveryMethod is null)
            throw new NotFoundException($"The delivery method with id: {deliveryMethodId} doesn't exist in the database.");
    }
}


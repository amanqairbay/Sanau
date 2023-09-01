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

    public async Task CheckDeliveryMethodExists(Guid deliveryMethodId)
    {
        var deliveryMethod = await _repository.DeliveryMethodRepository.GetByIdAsync(deliveryMethodId, trackChanges: false);

        if (deliveryMethod is null)
            throw new DeliveryMethodNotFoundException(deliveryMethodId);
    }
}


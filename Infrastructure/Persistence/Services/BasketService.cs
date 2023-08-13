using Application.Repositories;
using Application.Services;
using Domain.Entities;

namespace Persistence.Services;

/// <summary>
/// Represents a basket service.
/// </summary>
internal sealed class BasketService : IBasketService
{
    private readonly IRepositoryManager _repository;

    public BasketService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the basket by identifier.
    /// </summary>
    /// <param name="id">Basket identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the basket.
    /// </returns>
    public async Task<CustomerBasket> GetBasketByIdAsync(string id)
    {
        var basket = await _repository.BasketRepository.GetBasketAsync(id);

        return basket ?? new CustomerBasket(id);
    }

    /// <summary>
    /// Updates the basket.
    /// </summary>
    /// <param name="basket">Basket.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the basket.
    /// </returns>
    public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
    {
        var updatedBasket = await _repository.BasketRepository.UpdateBasketAsync(basket);

        return updatedBasket;
    }

    /// <summary>
    /// Deletes the basket by identifier.
    /// </summary>
    /// <param name="id">Basket identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteBasketAsync(string id)
    {
        await _repository.BasketRepository.DeleteBasketAsync(id);
    }
}
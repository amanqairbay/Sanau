using Domain.Entities;

namespace Application.Repositories;

/// <summary>
/// Represents a basket repository.
/// </summary>
public interface IBasketRepository
{
    /// <summary>
    /// Gets the customer basket.
    /// </summary>
    /// <param name="basketId">Basket identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<CustomerBasket?> GetBasketAsync(string basketId);

    /// <summary>
    /// Updates the customer basket.
    /// </summary>
    /// <param name="basket">Basket.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);

    /// <summary>
    /// Deletes the customer basket.
    /// </summary>
    /// <param name="basketId">Basket identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<bool> DeleteBasketAsync(string basketId);
}
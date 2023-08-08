using Domain.Entities;

namespace Application.Services;

/// <summary>
/// Represents a basket service.
/// </summary>
public interface IBasketService
{
    /// <summary>
    /// Gets the basket by identifier.
    /// </summary>
    /// <param name="id">Basket identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the basket.
    /// </returns>
    Task<CustomerBasket> GetBasketByIdAsync(string id);

    /// <summary>
    /// Updates the basket.
    /// </summary>
    /// <param name="basket">Basket.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the basket.
    /// </returns>
    Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);

    /// <summary>
    /// Deletes the basket by identifier.
    /// </summary>
    /// <param name="id">Basket identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteBasketAsync(string id);
}
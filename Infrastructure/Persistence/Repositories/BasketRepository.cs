using System.Text.Json;
using Application.Repositories;
using Domain.Entities;
using StackExchange.Redis;

namespace Persistence.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDatabase _database;

    public BasketRepository(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    public BasketRepository()
    {
    }

    /// <summary>
    /// Gets the customer basket.
    /// </summary>
    /// <param name="basketId">Basket identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<CustomerBasket?> GetBasketAsync(string basketId)
    {
        var data = await _database.StringGetAsync(basketId);

        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data!);
    }

    /// <summary>
    /// Updates the customer basket.
    /// </summary>
    /// <param name="basket">Basket.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
    {
        var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

        if (!created) return null;

        return await GetBasketAsync(basket.Id);
    }

    /// <summary>
    /// Deletes the customer basket.
    /// </summary>
    /// <param name="basketId">Basket identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<bool> DeleteBasketAsync(string basketId)
    {
        return await _database.KeyDeleteAsync(basketId);
    }
}
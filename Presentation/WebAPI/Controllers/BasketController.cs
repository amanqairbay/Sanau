using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BasketController : BaseApiController
{
    private readonly IServiceManager _service;

    public BasketController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Gets a basket.
    /// </summary>
    /// <param name="id">Basket identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the basket.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetBasket(string id)
    {
        var basket = await _service.BasketService.GetBasketByIdAsync(id);

        return Ok(basket);
    }

    /// <summary>
    /// Updates a basket.
    /// </summary>
    /// <param name="basket">Basket.</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the updated basket.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> UpdateBasketAsync(CustomerBasket basket)
    {
        var updatedBasket = await _service.BasketService.UpdateBasketAsync(basket);

        return Ok(updatedBasket);
    }

    /// <summary>
    /// Deletes a basket.
    /// </summary>
    /// <param name="id">Basket identifier.</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    [HttpDelete]
    public async Task DeleteBasketAsync(string id)
    {
        await _service.BasketService.DeleteBasketAsync(id);
    }
}
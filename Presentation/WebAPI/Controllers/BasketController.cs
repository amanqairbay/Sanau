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

    [HttpGet]
    public async Task<IActionResult> GetBasket(string id)
    {
        var basket = await _service.BasketService.GetBasketByIdAsync(id);

        return Ok(basket);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBasketAsync(CustomerBasket basket)
    {
        var updatedBasket = await _service.BasketService.UpdateBasketAsync(basket);

        return Ok(updatedBasket);
    }

    [HttpDelete]
    public async Task DeleteBasketAsync(string id)
    {
        await _service.BasketService.DeleteBasketAsync(id);
    }
}
using Application.Common.DTOs;
using Application.Services;
using Domain.Entities.OrderAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers;

public class OrdersController : BaseApiController
{
    private readonly IServiceManager _service;

    public OrdersController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Creates an order.
    /// </summary>
    /// <param name="orderDto">Data transfer object for order creating.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the created order.
    /// </returns>
    /// <response code="201">If the order is created.</response>
    /// <response code="400">If the order is null.</response>
    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder(OrderDto orderDto)
    {
        var order = await _service.OrderService.CreateOrderAsync(orderDto);

        return CreatedAtRoute("OrderById", new { id = order.Id }, order);
    }

    /// <summary>
    /// Gets user's orders.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains user's orders.
    /// </returns>
    /// <response code="200">If the orders exist.</response>
    /// <response code="401">If the user is unauthorized.</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetOrdersForUser()
    {
        var orders = await _service.OrderService.GetOrdersForUserAsync();

        return Ok(orders);
    }

    /// <summary>
    /// Gets orders by identifiers.
    /// </summary>
    /// <param name="id">Order identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the order.
    /// </returns>
    /// <response code="200">If the order exists.</response>
    /// <response code="401">If the user is unauthorized.</response>
    /// <response code="404">If the order doesn't exist.</response>
    [HttpGet("{id:guid}", Name = "OrderById")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderByIdForUser(Guid id)
    {
        var order = await _service.OrderService.GetOrderByIdAsync(id);

        return Ok(order);
    }

    /// <summary>
    /// Gets delivery methods.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains delivery methods.
    /// </returns>
    [HttpGet("deliveryMethods")]
    public async Task<IActionResult> GetDeliveryMethods()
    {
        var deliveryMethods = await _service.OrderService.GetDeliveryMethodsAsync();

        return Ok(deliveryMethods);
    }

}
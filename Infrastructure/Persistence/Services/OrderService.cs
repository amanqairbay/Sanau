using System.Security.Claims;
using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.OrderAggregate;
using Microsoft.AspNetCore.Http;

namespace Persistence.Services;

/// <summary>
/// Represents an order service.
/// </summary>
internal sealed class OrderService : IOrderService
{
    #region fields

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    #endregion fields

    #region constructors

    public OrderService(
        IHttpContextAccessor httpContextAccessor,
        IRepositoryManager repository,
        IMapper mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _repository = repository;
        _mapper = mapper;
    }

    #endregion  constructors

    /// <summary>
    /// Creates an order.
    /// </summary>
    /// <param name="orderDto">Data transfer object for order.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the created order.
    /// </returns>
    /// <exception cref="BadRequestException">Thrown when there are problems with creating an order.</exception>
    public async Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto)
    {
        var buyerEmail = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

        var address = _mapper.Map<AddressDto, Domain.Entities.OrderAggregate.Address>(orderDto.ShipToAddress);

        var order = await CreateAndGetOrderAsync(buyerEmail!, orderDto.deliveryMethodId, orderDto.basketId, address) ?? throw new BadRequestException("There are problems with creating an order.");

        return order;
    }

    /// <summary>
    /// Gets user's orders. 
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the user's orders.
    /// </returns>
    public async Task<IReadOnlyList<OrderToReturnDto>> GetOrdersForUserAsync()
    {
        var buyerEmail = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

        var orders = await _repository.OrderRepository.GetOrdersForUserAsync(buyerEmail, trackChanges: false);

        return _mapper.Map<IReadOnlyList<OrderToReturnDto>>(orders);
    }

    /// <summary>
    /// Gets order by identifier.
    /// </summary>
    /// <param name="orderId">Order identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the order.
    /// </returns>
    /// <exception cref="NotFoundException">Thrown when the order doesn't exist in the database.</exception>
    public async Task<OrderToReturnDto?> GetOrderByIdAsync(Guid orderId)
    {
        var buyerEmail = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

        var order = await _repository.OrderRepository
            .GetOrderByIdAsync(orderId, buyerEmail, trackChanges: false) ?? throw new NotFoundException($"The order with id: {orderId} doesn't exist in the database.");

        return _mapper.Map<OrderToReturnDto>(order);
    }

    /// <summary>
    /// Gets delivery methods.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the delivery methods.
    /// </returns>
    public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
        var deliveryMethods = await _repository.DeliveryMethodRepository.GetDeliveryMethodsAsync(trackChanges: false);

        return deliveryMethods;
    }

    #region private methods

    /// <summary>
    /// Creates and returns an order.
    /// </summary>
    /// <param name="buyerEmail">Buyer email.</param>
    /// <param name="deliveryMethodId">Delivery method identifier.</param>
    /// <param name="basketId">Basket identifier.</param>
    /// <param name="shippingAddress">Shipping address.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the order.
    /// </returns>
    private async Task<OrderToReturnDto> CreateAndGetOrderAsync(string buyerEmail, Guid deliveryMethodId, string basketId, Domain.Entities.OrderAggregate.Address shippingAddress)
    {
        // get basket from repository
        var basket = await GetBasketAndCheckIfExistsAsync(basketId);

        // get items from the product repository
        var items = new List<OrderItem>();

        foreach (var item in basket!.Items)
        {
            var productItem = await _repository.ProductRepository.GetProductByIdAsync(item.Id, trackChanges: false);
            var itemOrdered = new ProductItemOrdered(productItem!.Id, productItem.Name!, productItem.ImageUrl!);
            var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);

            items.Add(orderItem);
        }

        // get delivery method from repo
        // var deliveryMethod = await _repository.DeliveryMethodRepository.GetByIdAsync(deliveryMethodId, trackChanges: false);
        await CheckDeliveryMethodExists(deliveryMethodId);

        // calculate subtotal
        var subtotal = items.Sum(item => item.Price * item.Quantity);

        // create order
        var createdOrder = new Order(items, buyerEmail, shippingAddress, deliveryMethodId!, subtotal);
        _repository.OrderRepository.CreateOrder(createdOrder);

        // save to db
        await _repository.SaveAsync();

        // delete basket
        await _repository.BasketRepository.DeleteBasketAsync(basketId);

        // return order.
        var order = await _repository.OrderRepository.GetOrderByIdAsync(createdOrder.Id, buyerEmail, trackChanges: false);

        return _mapper.Map<OrderToReturnDto>(order);
    }

    /// <summary>
    /// Checks if the basket exists.
    /// </summary>
    /// <param name="basketId">Basket identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="NotFoundException">Thrown when the basket doesn't exist in the database.</exception>
    private async Task<CustomerBasket> GetBasketAndCheckIfExistsAsync(string basketId)
    {
        return await _repository.BasketRepository.GetBasketAsync(basketId)
            ?? throw new NotFoundException($"The basket with id: {basketId} doesn't exist in the database.");   
    }

    /// <summary>
    /// Checks if the delivery method exists.
    /// </summary>
    /// <param name="deliveryMethodId">Delivery  methods identifier.</param>
    /// <returns></returns>
    /// <exception cref="NotFoundException">Thrown when the delivery method doesn't exist in the database.</exception>
    private async Task CheckDeliveryMethodExists(Guid deliveryMethodId)
    {
        var deliveryMethod = await _repository.DeliveryMethodRepository.GetByIdAsync(deliveryMethodId, trackChanges: false);

        if (deliveryMethod is null)
            throw new NotFoundException($"The delivery method with id: { deliveryMethodId } doesn't exist in the database.");
    }

    #endregion private methods
}
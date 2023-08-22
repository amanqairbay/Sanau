using Application.Common.DTOs;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;

namespace Persistence.Services;

/// <summary>
/// Represents a basket service.
/// </summary>
internal sealed class BasketService : IBasketService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public BasketService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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
    public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasketDto basketDto)
    {
        var basket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basketDto);
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
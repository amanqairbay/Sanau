using Application.Common.DTOs;
using AutoMapper;
using Domain.Entities.OrderAggregate;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Helpers;

/// <summary>
/// Represents an order item's image url resolver.
/// </summary>
public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
{
    private readonly IConfiguration _configuration;

    public OrderItemUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Implementors use source object to provide a destination object.
    /// </summary>
    /// <param name="source">Source object.</param>
    /// <param name="destination">Destination object, if exists.</param>
    /// <param name="destMember">Destination member.</param>
    /// <param name="context">The context of the mapping.</param>
    /// <returns>Result, typically build from the source resolution result.</returns>
    public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ItemOrdered.ImageUrl))
        {
            return _configuration["ApiUrl"] + source.ItemOrdered.ImageUrl;
        }

        return null!;
    }
}
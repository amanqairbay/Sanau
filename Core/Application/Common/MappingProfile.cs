using Application.Common.DTOs;
using Application.Common.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;
using Domain.Entities.OrderAggregate;

namespace Application.Common;

/// <summary>
/// Provides a named configuration for maps. Naming conventions become scoped per profile.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
#nullable disable
        CreateMap<Domain.Entities.Identity.Address, AddressDto>().ReverseMap();
        CreateMap<Brand, BrandDto>()
            .ForMember(d => d.ImageUrl, o => o.MapFrom<ImageUrlResolver<Brand, BrandDto>>());

        CreateMap<Category, CategoryDto>();
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ImageUrl, o => o.MapFrom<ImageUrlResolver<Product, ProductDto>>());

        CreateMap<BrandForCreationDto, Brand>();
        CreateMap<CategoryForCreationDto, Category>();
        CreateMap<ProductForCreationDto, Product>();

        CreateMap<ProductForUpdateDto, Product>();
        CreateMap<BrandForUpdateDto, Brand>();

        CreateMap<UserForRegistrationDto, AppUser>();

        CreateMap<CustomerBasketDto, CustomerBasket>();
        CreateMap<BasketItemDto, BasketItem>();

        CreateMap<AddressDto, Domain.Entities.OrderAggregate.Address>();

        CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
            .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.Id))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
            .ForMember(d => d.ImageUrl, o => o.MapFrom<OrderItemUrlResolver>());
#nullable disable
    }
}
using Application.Common.DTOs;
using Application.Common.Helpers;
using AutoMapper;
using Domain.Entities;

namespace Application.Common;

/// <summary>
/// Provides a named configuration for maps. Naming conventions become scoped per profile.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
#nullable disable
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
#nullable disable
    }
}
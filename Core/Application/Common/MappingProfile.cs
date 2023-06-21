using Application.Common.DTOs;
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
        CreateMap<Brand, BrandDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Product, ProductDto>();

        CreateMap<BrandForCreationDto, Brand>();
        CreateMap<CategoryForCreationDto, Category>();
        CreateMap<ProductForCreationDto, Product>();
    }
}
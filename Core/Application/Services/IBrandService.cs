using Application.Common.DTOs;

namespace Application.Services;

/// <summary>
/// Represents a brand service.
/// </summary>
public interface IBrandService
{
    IEnumerable<BrandDto> GetAllBrands(bool trackChanges);
}
using Application.Common.DTOs;

namespace Application.Services;

/// <summary>
/// Represents a brand service.
/// </summary>
public interface IBrandService
{
    /// <summary>
    /// Gets all brands.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    Task<IEnumerable<BrandDto>> GetAllBrandsAsync(bool trackChanges);

    /// <summary>
    /// Gets a brand by identifier.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    Task<BrandDto?> GetBrandByIdAsync(Guid brandId, bool trackChanges);
}
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

    /// <summary>
    /// Gets the brands by identifiers.
    /// </summary>
    /// <param name="brandIds">Brands identifiers.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    Task<IEnumerable<BrandDto>> GetBrandsByIdsAsync(IEnumerable<Guid> brandIds, bool trackChanges);

    /// <summary>
    /// Creates a brand.
    /// </summary>
    /// <param name="brandForCreationDto">Brand data transfer object for creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    Task<BrandDto> CreateBrandAsync(BrandForCreationDto brandForCreationDto);

    /// <summary>
    /// Creates a collection of brands.
    /// </summary>
    /// <param name="BrandDtos">Brand data transfer object.</param>
    /// <param name="BrandIds">Brands identifiers.</param>
    /// <param name="brandForCreationDtos">Brand data transfer object for creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    Task<(IEnumerable<BrandDto> BrandDtos, string BrandIds)> CreateBrandCollectionAsync(IEnumerable<BrandForCreationDto> brandForCreationDtos);

    /// <summary>
    /// Updates a brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="brandForUpdateDto">Brand data transfer object for update.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns></returns>
    Task UpdateBrandAsync(Guid brandId, BrandForUpdateDto brandForUpdateDto, bool trackChanges);

    /// <summary>
    /// Deletes a brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteBrandAsync(Guid brandId, bool trackChanges);
}
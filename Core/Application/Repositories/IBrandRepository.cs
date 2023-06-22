using Domain.Entities;

namespace Application.Repositories;

/// <summary>
/// Represents a brand repository.
/// </summary>
public interface IBrandRepository
{
    /// <summary>
    /// Gets all brands.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>Returns all brands.</returns>
    IEnumerable<Brand> GetAllBrands(bool trackChanges);

    /// <summary>
    /// Gets all brands.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges);

    /// <summary>
    /// Gets a brand by identifier.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// Returns a brand.
    /// </returns>
    Brand? GetBrandById(Guid brandId, bool trackChanges);

    /// <summary>
    /// Gets a brand by identifier.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    Task<Brand?> GetBrandByIdAsync(Guid brandId, bool trackChanges);

    /// <summary>
    /// Gets the brands by identifiers.
    /// </summary>
    /// <param name="brandIds">Brand identifiers.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    Task<IEnumerable<Brand>> GetBrandsByIdsAsync(IEnumerable<Guid> brandIds, bool trackChanges);

    /// <summary>
    /// Creates a brand.
    /// </summary>
    /// <param name="brand">Brand entity.</param>
    void CreateBrand(Brand brand);

    /// <summary>
    /// Deletes a brand.
    /// </summary>
    /// <param name="brand">Brand entity.</param>
    void DeleteBrand(Brand brand);
}
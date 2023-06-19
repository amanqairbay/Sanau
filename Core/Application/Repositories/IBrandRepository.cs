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
}
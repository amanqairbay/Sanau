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
    /// <param name="trackChanges">
    /// Used to improve the performance of read-only queries. When it is set to false, 
    /// the AsNoTracking method is connected to the request to inform EF Core 
    /// that it does not need to track changes for the required objects. 
    /// This greatly improves the speed of query execution.
    /// </param>
    /// <returns>Returns all brands.</returns>
    IEnumerable<Brand> GetAllBrands(bool trackChanges);
}
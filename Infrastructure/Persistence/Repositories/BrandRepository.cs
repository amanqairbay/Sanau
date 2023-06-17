using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

/// <summary>
/// Represents the brand repository class.
/// </summary>
public class BrandRepository : BaseRepository<Brand>, IBrandRepository
{
#region constructor
    public BrandRepository(DataContext context) : base(context)
    {
        
    }

#endregion constructor

    /// <summary>
    /// Gets all brands.
    /// </summary>
    /// <param name="trackChanges">
    /// Used to improve the performance of read-only queries. When it is set to false, 
    /// the AsNoTracking method is connected to the request to inform EF Core 
    /// that it does not need to track changes for the required objects. 
    /// This greatly improves the speed of query execution.</param>
    /// <returns>Returns all brands.</returns>
    public IEnumerable<Brand> GetAllBrands(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();
}
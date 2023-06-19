using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>Returns all brands.</returns>
    public IEnumerable<Brand> GetAllBrands(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();

    /// <summary>
    /// Gets all brands.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    public async Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(b => b.Name)
            .ToListAsync();
    
    /// <summary>
    /// Gets a brand.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// Returns a brand.
    /// </returns>
    public Brand? GetBrandById(Guid brandId, bool trackChanges) => 
        FindByCondition(b => b.Id.Equals(brandId), trackChanges)
        .SingleOrDefault();

    /// <summary>
    /// Gets a brand by identifier.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    public async Task<Brand?> GetBrandByIdAsync(Guid brandId, bool trackChanges) =>
        await FindByCondition(b => b.Id.Equals(brandId), trackChanges)
            .SingleOrDefaultAsync();
}
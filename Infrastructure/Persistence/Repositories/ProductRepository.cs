using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

/// <summary>
/// Represents the product repository class.
/// </summary>
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DataContext context) : base(context)
    {
        
    }

    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

    /// <summary>
    /// Gets a product for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<Product?> GetSingleProductForBrandAsync(Guid brandId, Guid productId, bool trackChanges) =>
        await FindByCondition(p => p.BrandId.Equals(brandId) && p.Id.Equals(productId), trackChanges)
              .SingleOrDefaultAsync();
    
    /// <summary>
    /// Gets a product for category.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<Product?> GetSingleProductForCategoryAsync(Guid categoryId, Guid productId, bool trackChanges) =>
        await FindByCondition(p => p.CategoryId.Equals(categoryId) && p.Id.Equals(productId), trackChanges)
              .SingleOrDefaultAsync();

    /// <summary>
    /// Gets the products per brand.
    /// </summary>
    /// <param name="brandId">PBrand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IEnumerable<Product>> GetProductsForBrandAsync(Guid brandId, bool trackChanges) => 
        await FindByCondition(p => p.BrandId.Equals(brandId), trackChanges)
              .OrderBy(p => p.Name).ToListAsync();

    /// <summary>
    /// Gets the products per category.
    /// </summary>
    /// <param name="brandId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IEnumerable<Product>> GetProductsForCategoryAsync(Guid brandId, bool trackChanges) => 
        await FindByCondition(p => p.CategoryId.Equals(brandId), trackChanges)
              .OrderBy(p => p.Name).ToListAsync();
}
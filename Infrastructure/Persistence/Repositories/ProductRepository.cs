using Application.Common.RequestFeatures;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Extensions;

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
    /// Gets the paged products.
    /// </summary>
    /// <param name="productParameters">Product parameters.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products.
    /// </returns>
    public async Task<PagedList<Product>> GetPagedProductsAsync(ProductParameters productParameters, bool trackChanges)
    {
        var products = await FindAll(trackChanges)
            .FilterProducts(productParameters.MinPrice, productParameters.MaxPrice)
            .Search(productParameters.SearchTerm!)
            .Sort(productParameters.OrderBy!)
            .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
            .Take(productParameters.PageSize)
            .ToListAsync();
        
        var count = await FindAll(trackChanges).CountAsync();

        return new PagedList<Product>(products, count, productParameters.PageNumber, productParameters.PageSize);
    }

    /// <summary>
    /// Gets a product by identifier.
    /// </summary>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges) =>
        await FindByCondition(p => p.Id.Equals(productId), trackChanges)
        .SingleOrDefaultAsync();

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
            .OrderBy(p => p.Name)
            .ToListAsync();

    /// <summary>
    /// Gets the paged products for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productParameters">Product parameters.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products.
    /// </returns>
    public async Task<PagedList<Product>> GetPagedProductsForBrandAsync(Guid brandId, ProductParameters productParameters, bool trackChanges)
    {
        var products = await FindByCondition(p => p.BrandId.Equals(brandId) && 
            (p.Price >= productParameters.MinPrice && p.Price <= productParameters.MaxPrice), trackChanges)
                .OrderBy(p => p.Name)
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();
        
        var count = await FindByCondition(p => p.BrandId.Equals(brandId) && 
            (p.Price >= productParameters.MinPrice && p.Price <= productParameters.MaxPrice), trackChanges).CountAsync();

        return new PagedList<Product>(products, count, productParameters.PageNumber, productParameters.PageSize);
    }

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

    /// <summary>
    /// Creates a product for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="product">Product entity.</param>
    public void CreateProductForBrand(Guid brandId, Product product)
    {
        product.BrandId = brandId;
        Create(product);
    }

    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <param name="product">Product entity.</param>
    public void DeleteProduct(Product product) => Delete(product);
}
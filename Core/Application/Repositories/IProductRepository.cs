using Domain.Entities;

namespace Application.Repositories;

/// <summary>
/// Represents a product repository.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);

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
    Task<Product?> GetSingleProductForBrandAsync(Guid brandId, Guid productId, bool trackChanges);

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
    Task<Product?> GetSingleProductForCategoryAsync(Guid categoryId, Guid productId, bool trackChanges);

    /// <summary>
    /// Gets the products per brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    Task<IEnumerable<Product>> GetProductsForBrandAsync(Guid brandId, bool trackChanges);

    /// <summary>
    /// Gets the products per category.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    Task<IEnumerable<Product>> GetProductsForCategoryAsync(Guid categoryId, bool trackChanges);

    /// <summary>
    /// Creates a product for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="product">Product entity.</param>
    void CreateProductForBrand(Guid brandId, Product product);

    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <param name="product">Product entity.</param>
    void DeleteProduct(Product product);
}
using Application.Common.DTOs;

namespace Application.Services;

/// <summary>
/// Represents a product service.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    Task<IEnumerable<ProductDto>> GetProductsAsync(bool trackChanges);

    /// <summary>
    /// Gets the product for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    Task<ProductDto?> GetSingleProductForBrandAsync(Guid brandId, Guid productId, bool trackChanges);

    /// <summary>
    /// Gets the product for category.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    Task<ProductDto?> GetSingleProductForCategoryAsync(Guid categoryId, Guid productId, bool trackChanges);

    /// <summary>
    /// Gets the products per brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    Task<IEnumerable<ProductDto>> GetProductsForBrandAsync(Guid brandId, bool trackChanges);

    /// <summary>
    /// Gets the products per category.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>

    Task<IEnumerable<ProductDto>> GetProductsForCategoryAsync(Guid categoryId, bool trackChanges);
}
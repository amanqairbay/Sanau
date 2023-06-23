using Application.Common.DTOs;
using Application.Common.RequestFeatures;

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
    /// Gets the paged products.
    /// </summary>
    /// <param name="productParameters">Product parameters.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products.
    /// </returns>
    Task<(IEnumerable<ProductDto> Products, MetaData MetaData)> GetPagedProductsAsync(ProductParameters productParameters, bool trackChanges);

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
    /// Gets the paged products for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productParameters">Product parameters.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products.
    /// </returns>
    Task<(IEnumerable<ProductDto> Products, MetaData MetaData)> GetPagedProductsForBrandAsync(Guid brandId, ProductParameters productParameters, bool trackChanges);

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

    /// <summary>
    /// Creates a product for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productForCreationDto">Product data transfer object for creation.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a product.
    /// </returns>
    Task<ProductDto> CreateProductForBrandAsync(Guid brandId, ProductForCreationDto productForCreationDto, bool trackChanges);

    /// <summary>
    /// Updates a product for brand
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="productForUpdateDto">Product data transfer object for update.</param>
    /// <param name="brandTrackChanges">Used to improve the performance of read-only queries.</param>
    /// <param name="productTrackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateProductForBrandAsync(Guid brandId, Guid productId, ProductForUpdateDto productForUpdateDto, 
        bool brandTrackChanges, bool productTrackChanges);

    /// <summary>
    /// Deletes a product for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteProductForBrandAsync(Guid brandId, Guid productId, bool trackChanges);
}
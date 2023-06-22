using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Logging;

namespace Persistence.Services;

/// <summary>
/// Represents a product service.
/// </summary>
internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ProductService(
        IRepositoryManager repository, 
        ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IEnumerable<ProductDto>> GetProductsAsync(bool trackChanges)
    {
        var products = await _repository.ProductRepository.GetAllProductsAsync(trackChanges);
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

        return productsDto;
    }

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
    public async Task<ProductDto?> GetSingleProductForBrandAsync(Guid brandId, Guid productId, bool trackChanges)
    {
        var brand = await _repository.BrandRepository.GetBrandByIdAsync(brandId, trackChanges);
        if (brand is null)
            throw new BrandNotFoundException(brandId);

        var product = await _repository.ProductRepository.GetSingleProductForBrandAsync(brandId, productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

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
    public async Task<ProductDto?> GetSingleProductForCategoryAsync(Guid categoryId, Guid productId, bool trackChanges)
    {
        var category = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
        if (category is null)
            throw new CategoryNotFoundException(categoryId);

        var product = await _repository.ProductRepository.GetSingleProductForCategoryAsync(categoryId, productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    /// <summary>
    /// Gets the products per brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IEnumerable<ProductDto>> GetProductsForBrandAsync(Guid brandId, bool trackChanges)
    {
        var brand = await _repository.BrandRepository.GetBrandByIdAsync(brandId, trackChanges);

        if (brand is null)
            throw new BrandNotFoundException(brandId);

        var products = await _repository.ProductRepository.GetProductsForBrandAsync(brandId, trackChanges);
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

        return productsDto;
    }

    /// <summary>
    /// Gets the products per category.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IEnumerable<ProductDto>> GetProductsForCategoryAsync(Guid categoryId, bool trackChanges)
    {
        var category = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);

        if (category is null)
            throw new CategoryNotFoundException(categoryId);

        var products = await _repository.ProductRepository.GetProductsForCategoryAsync(categoryId, trackChanges);
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

        return productsDto;
    }

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
    public async Task<ProductDto> CreateProductForBrandAsync(Guid brandId, ProductForCreationDto productForCreationDto, bool trackChanges)
    {
        var brand = await _repository.BrandRepository.GetBrandByIdAsync(brandId, trackChanges);
        if (brand is null)
            throw new BrandNotFoundException(brandId);

        var product = _mapper.Map<Product>(productForCreationDto);

        _repository.ProductRepository.CreateProductForBrand(brandId, product);
        await _repository.SaveAsync();

        var productDto = _mapper.Map<ProductDto>(product);

        return productDto;
    }

    /// <summary>
    /// Updates a product for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="productForUpdateDto">Product data transfer object for update.</param>
    /// <param name="brandTrackChanges">Used to improve the performance of read-only queries.</param>
    /// <param name="productTrackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UpdateProductForBrandAsync(Guid brandId, Guid productId, ProductForUpdateDto productForUpdateDto, 
        bool brandTrackChanges, bool productTrackChanges)
    {
        var brand = await _repository.BrandRepository.GetBrandByIdAsync(brandId, brandTrackChanges);
        if (brand is null)
            throw new BrandNotFoundException(brandId);
        
        var product = await _repository.ProductRepository.GetSingleProductForBrandAsync(brandId, productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        
        _mapper.Map(productForUpdateDto, product);
        await _repository.SaveAsync();
    }

    /// <summary>
    /// Deletes a product for brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteProductForBrandAsync(Guid brandId, Guid productId, bool trackChanges)
    {
        var brand = await _repository.BrandRepository.GetBrandByIdAsync(brandId, trackChanges);
        if (brand is null)
            throw new BrandNotFoundException(brandId);

        var product = await _repository.ProductRepository.GetSingleProductForBrandAsync(brandId, productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        _repository.ProductRepository.DeleteProduct(product);
        await _repository.SaveAsync();
    }
}
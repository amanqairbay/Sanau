using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Common.RequestFeatures;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;

namespace Persistence.Services;

/// <summary>
/// Represents a product service.
/// </summary>
internal sealed class ProductService : IProductService
{
    #region fields

    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    #endregion fields

    #region constructor

    public ProductService(
        IRepositoryManager repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #endregion constructor

    #region get methods

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
    /// Gets the paged products.
    /// </summary>
    /// <param name="productParameters">Product parameters.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products.
    /// </returns>
    public async Task<(IEnumerable<ProductDto> Products, MetaData MetaData)> GetPagedProductsAsync(ProductParameters productParameters, bool trackChanges)
    {
        if (!productParameters.ValidPriceRange)
            throw new MaxPriceRangeBadRequestException();

        var productsWithMetaData = await _repository.ProductRepository.GetPagedProductsAsync(productParameters, trackChanges);

        var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);

        return (Products: productsDtos, MetaData: productsWithMetaData.MetaData);
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
        await CheckIfBrandExistsAsync(brandId, trackChanges);

        var product = await GetProductForBrandAndCheckIfExistsAsync(brandId, productId, trackChanges);
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
        await CheckIfCategoryExistsAsync(categoryId, trackChanges);

        var product = await GetProductForCategoryAndCheckIfExistsAsync(categoryId, productId, trackChanges);
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
        await CheckIfBrandExistsAsync(brandId, trackChanges);

        var products = await _repository.ProductRepository.GetProductsForBrandAsync(brandId, trackChanges);
        var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

        return productsDtos;
    }

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
    public async Task<(IEnumerable<ProductDto> Products, MetaData MetaData)> GetPagedProductsForBrandAsync(Guid brandId, ProductParameters productParameters, bool trackChanges)
    {
        if (!productParameters.ValidPriceRange)
            throw new MaxPriceRangeBadRequestException();
            
        await CheckIfBrandExistsAsync(brandId, trackChanges);

        var productsWithMetaData = await _repository.ProductRepository.GetPagedProductsForBrandAsync(brandId, productParameters, trackChanges);

        var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);

        return (Products: productsDtos, MetaData: productsWithMetaData.MetaData);
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
        await CheckIfCategoryExistsAsync(categoryId, trackChanges);

        var products = await _repository.ProductRepository.GetProductsForCategoryAsync(categoryId, trackChanges);
        var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

        return productsDtos;
    }

    #endregion get methods

    #region create/update/delete methods

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
        await CheckIfBrandExistsAsync(brandId, trackChanges);

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
        await CheckIfBrandExistsAsync(brandId, brandTrackChanges);
        
        var product = await GetProductForBrandAndCheckIfExistsAsync(brandId, productId, productTrackChanges);
        
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
        await CheckIfBrandExistsAsync(brandId, trackChanges);

        var product = await GetProductForBrandAndCheckIfExistsAsync(brandId, productId, trackChanges);

        _repository.ProductRepository.DeleteProduct(product);
        await _repository.SaveAsync();
    }

    #endregion create/update/delete methods

    #region private methods

    /// <summary>
    /// Checks if the brand exists.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    private async Task CheckIfBrandExistsAsync(Guid brandId, bool trackChanges)
    {
        var brand = await _repository.BrandRepository.GetBrandByIdAsync(brandId, trackChanges);
        if (brand is null)
            throw new BrandNotFoundException(brandId);
    }

    /// <summary>
    /// Gets a product for brand and checks if it exists.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a product.
    /// </returns>
    private async Task<Product> GetProductForBrandAndCheckIfExistsAsync(Guid brandId, Guid productId, bool trackChanges)
    {
        var product = await _repository.ProductRepository.GetSingleProductForBrandAsync(brandId, productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        return product;
    }

    /// <summary>
    /// Checks if the category exists.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    private async Task CheckIfCategoryExistsAsync(Guid categoryId, bool trackChanges)
    {
        var category = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
        if (category is null)
            throw new CategoryNotFoundException(categoryId);
    }

    /// <summary>
    /// Gets a product for category and checks if it exists.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a product.
    /// </returns>
    private async Task<Product> GetProductForCategoryAndCheckIfExistsAsync(Guid categoryId, Guid productId, bool trackChanges)
    {
        var product = await _repository.ProductRepository.GetSingleProductForCategoryAsync(categoryId, productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        return product;
    }

    #endregion private methods
}
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Logging;

namespace Persistence.Services;

/// <summary>
/// Represents a service manager.
/// </summary>
public sealed class ServiceManager : IServiceManager
{
#region fields
    private readonly Lazy<IBrandService> _brandService;
    private readonly Lazy<IBasketService> _basketService;
    private readonly Lazy<ICategoryService> _categoryService;
    private readonly Lazy<IProductService> _productService;

#endregion fields

#region properties
    /// <summary>
    /// Gets a brand service value.
    /// </summary>
    public IBrandService BrandService => _brandService.Value;

    /// <summary>
    /// Gets a basket service.
    /// </summary>
    public IBasketService BasketService => _basketService.Value;

    /// <summary>
    /// Gets a category service value.
    /// </summary>
    public ICategoryService CategoryService => _categoryService.Value;

    /// <summary>
    /// Gets a product service value.
    /// </summary>
    public IProductService ProductService => _productService.Value;
#endregion properties

#region constructor
    public ServiceManager(
        IRepositoryManager repository, 
        ILoggerManager logger,
        IMapper mapper)
    {
        _brandService = new Lazy<IBrandService>(() => new BrandService(repository, logger, mapper));
        _basketService = new Lazy<IBasketService>(() => new BasketService(repository));
        _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository, logger, mapper));
        _productService = new Lazy<IProductService>(() => new ProductService(repository, logger, mapper));
    }

#endregion constructor
}
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Persistence.Services;

/// <summary>
/// Represents a service manager.
/// </summary>
public sealed class ServiceManager : IServiceManager
{
    #region fields

    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<IBrandService> _brandService;
    private readonly Lazy<IBasketService> _basketService;
    private readonly Lazy<ICategoryService> _categoryService;
    private readonly Lazy<IProductService> _productService;

    #endregion fields

    #region properties

    /// <summary>
    /// Gets an authentication service value.
    /// </summary>
    public IAuthenticationService AuthenticationService => _authenticationService.Value;

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
        IMapper mapper,
        UserManager<AppUser> userManager,
        IConfiguration configuration,
        ILoggerManager logger)
    {
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        _brandService = new Lazy<IBrandService>(() => new BrandService(repository, mapper));
        _basketService = new Lazy<IBasketService>(() => new BasketService(repository));
        _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository, mapper));
        _productService = new Lazy<IProductService>(() => new ProductService(repository, mapper));
    }

    #endregion constructor
}
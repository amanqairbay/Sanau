using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Logging;
using Microsoft.AspNetCore.Http;
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
    private readonly Lazy<IOrderService> _orderService;
    private readonly Lazy<IDeliveryMethodService> _deliveryMethodService;

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

    /// <summary>
    /// Gets an order service value.
    /// </summary>
    public IOrderService OrderService => _orderService.Value;

    /// <summary>
    /// Gets a delivery method service.
    /// </summary>
    public IDeliveryMethodService DeliveryMethodService => _deliveryMethodService.Value;

    #endregion properties

    #region constructor

    public ServiceManager(
        IRepositoryManager repository,
        IMapper mapper,
        UserManager<AppUser> userManager,
        IConfiguration configuration,
        ILoggerManager logger,
        IHttpContextAccessor httpContextAccessor)
    {
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, httpContextAccessor, configuration));
        _brandService = new Lazy<IBrandService>(() => new BrandService(repository, mapper));
        _basketService = new Lazy<IBasketService>(() => new BasketService(repository, mapper));
        _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository, mapper));
        _productService = new Lazy<IProductService>(() => new ProductService(repository, mapper));
        _orderService = new Lazy<IOrderService>(() => new OrderService(httpContextAccessor, repository, mapper));
        _deliveryMethodService = new Lazy<IDeliveryMethodService>(() => new DeliveryMethodService(repository));
    }

    #endregion constructor
}
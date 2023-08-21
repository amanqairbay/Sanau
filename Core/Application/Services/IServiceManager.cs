
using Microsoft.AspNetCore.Http;

namespace Application.Services;

/// <summary>
/// Represents a service manager.
/// </summary>
public interface IServiceManager
{
    /// <summary>
    /// Gets an authentication service.
    /// </summary>
    IAuthenticationService AuthenticationService { get; }

    /// <summary>
    /// Gets a brand service.
    /// </summary>
    IBrandService BrandService { get; }

    /// <summary>
    /// Gets a basket service.
    /// </summary>
    IBasketService BasketService { get; }

    /// <summary>
    /// Gets a category service.
    /// </summary>
    ICategoryService CategoryService { get; }

    /// <summary>
    /// Gets a product service.
    /// </summary>
    IProductService ProductService { get; }

}
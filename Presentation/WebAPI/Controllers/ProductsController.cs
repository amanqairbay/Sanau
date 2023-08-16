using System.Text.Json;
using Application.Common.RequestFeatures;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IServiceManager _service;

    public ProductsController(IServiceManager service)
    {
        _service = service;
    }

    #region GET methods

    /// <summary>
    /// Gets and returns a list of products by parameters.
    /// </summary>
    /// <param name="productParameters">The product params to get for.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the list of products.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAllPagedProducts([FromQuery] ProductParameters productParameters)
    {
        var pagedResult = await _service.ProductService.GetPagedProductsAsync(productParameters, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

        return Ok(pagedResult.Products);
    }

    /// <summary>
    /// Gets and returns a list of all products.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the list of all products.
    /// </returns>
    [HttpGet("all")]
    [Authorize(Roles ="Administrator")]
    [ApiExplorerSettings(GroupName = "v1")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _service.ProductService.GetProductsAsync(trackChanges: false);
        return Ok(products);
    }

    #endregion GET methods
}
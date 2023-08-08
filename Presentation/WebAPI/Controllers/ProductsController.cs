using System.Text.Json;
using Application.Common.RequestFeatures;
using Application.Services;
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

    [HttpGet]
    public async Task<IActionResult> GetAllPagedProducts([FromQuery] ProductParameters productParameters)
    {
        var pagedResult = await _service.ProductService.GetPagedProductsAsync(productParameters, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

        return Ok(pagedResult.Products);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _service.ProductService.GetProductsAsync(trackChanges: false);
        return Ok(products);
    }

#endregion GET methods
}
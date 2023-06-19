using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
//[Route("api/parent/{parentId}/products")]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("api/products")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _service.ProductService.GetProductsAsync(trackChanges: false);
        return Ok(products);
    }

    [HttpGet]
    [Route("api/brands/{brandId}/products/{id:guid}")]
    public async Task<IActionResult> GetSingleProductForBrand(Guid brandId, Guid id)
    {
        var product = await _service.ProductService.GetSingleProductForBrandAsync(brandId, id, trackChanges: false);
        return Ok(product);
    }

    [HttpGet]
    [Route("api/categories/{categoryId}/products/{id:guid}")]
    public async Task<IActionResult> GetSingleProductForCategory(Guid categoryId, Guid id)
    {
        var product = await _service.ProductService.GetSingleProductForCategoryAsync(categoryId, id, trackChanges: false);
        return Ok(product);
    }

    [HttpGet]
    [Route("api/brands/{brandId}/products")]
    public async Task<IActionResult> GetProuctsForBrand(Guid brandId)
    {
        var products = await _service.ProductService.GetProductsForBrandAsync(brandId, trackChanges: false);
        return Ok(products);
    }

    [HttpGet]
    [Route("api/categories/{categoryId}/products")]
    public async Task<IActionResult> GetProuctsForCategory(Guid categoryId)
    {
        var products = await _service.ProductService.GetProductsForCategoryAsync(categoryId, trackChanges: false);
        return Ok(products);
    }
}
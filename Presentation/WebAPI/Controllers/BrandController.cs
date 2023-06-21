using Microsoft.AspNetCore.Mvc;
using Application.Common.DTOs;
using Application.Services;
using WebAPI.ModelBinders;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/brands")]
public class BrandController : ControllerBase
{
    private readonly IServiceManager _service;

    public BrandController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBrands()
    {
        //throw new Exception("Exception");
        var brands = await _service.BrandService.GetAllBrandsAsync(trackChanges: false);
        return Ok(brands);
    }

    [HttpGet("{id:guid}", Name = "BrandById")]
    public async Task<IActionResult> GetBrand(Guid id)
    {
        var brand = await _service.BrandService.GetBrandByIdAsync(id, trackChanges: false);

        return Ok(brand);
    }

    [HttpGet("collection/({ids})", Name = "BrandCollection")]
    public async Task<IActionResult> GetBrandsByIds(
        [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var brands = await _service.BrandService.GetBrandsByIdsAsync(brandIds: ids, trackChanges: false);

        return Ok(brands);
    }

    [HttpGet("{id:guid}/products")]
    public async Task<IActionResult> GetBrandProducts(Guid id)
    {
        var products = await _service.ProductService.GetProductsForBrandAsync(brandId: id, trackChanges: false);
        return Ok(products);
    }

    [HttpGet("{id:guid}/products/{productId:guid}", Name = "GetBrandProduct")]
    public async Task<IActionResult> GetBrandProduct(Guid id, Guid productId)
    {
        var product = await _service.ProductService
            .GetSingleProductForBrandAsync(brandId: id, productId, trackChanges: false);

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromBody] BrandForCreationDto brandForCreationDto)
    {
        if (brandForCreationDto is null)
            return BadRequest("BrandForCreationDto object is null");

        var createdBrand = await _service.BrandService.CreateBrandAsync(brandForCreationDto);

        return CreatedAtRoute("BrandById", new { id = createdBrand.Id}, createdBrand);
    }

    [HttpPost("{id:guid}/products")]
    public async Task<IActionResult> CreateProductForBrand(Guid id, [FromBody]ProductForCreationDto productForCreationDto)
    {
        if (productForCreationDto is null)
            return BadRequest("ProductForCreation object iss null.");

        var createdProduct = await _service.ProductService
            .CreateProductForCompany(id, productForCreationDto, trackChanges: false);
        
        return CreatedAtRoute("GetBrandProduct", new { id, productId = createdProduct.Id }, createdProduct);
    }
}
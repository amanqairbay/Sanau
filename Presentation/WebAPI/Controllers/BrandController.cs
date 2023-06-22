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

    [HttpPost("collection")]
    public async Task<IActionResult> CreateBrandCollection([FromBody]IEnumerable<BrandForCreationDto> brandForCreationDtos)
    {
        var result = await _service.BrandService.CreateBrandCollectionAsync(brandForCreationDtos);

        return CreatedAtRoute("BrandCollection", new { ids = result.BrandIds }, result.BrandDtos );
    }

    [HttpPost("{id:guid}/products")]
    public async Task<IActionResult> CreateProductForBrand(Guid id, [FromBody]ProductForCreationDto productForCreationDto)
    {
        if (productForCreationDto is null)
            return BadRequest("ProductForCreation object is null.");

        var createdProduct = await _service.ProductService
            .CreateProductForBrandAsync(id, productForCreationDto, trackChanges: false);
        
        return CreatedAtRoute("GetBrandProduct", new { id, productId = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateBrand(Guid id, [FromBody]BrandForUpdateDto brandForUpdateDto)
    {
        if (brandForUpdateDto is null)
            return BadRequest("BrandForUpdateDto object is null.");

        await _service.BrandService.UpdateBrandAsync(brandId: id, brandForUpdateDto, trackChanges: true);

        return NoContent();
    }

    [HttpPut("{id:guid}/products/{productId:guid}")]
    public async Task<IActionResult> UpdateBrandProduct(Guid id, Guid productId, 
        [FromBody]ProductForUpdateDto productForUpdateDto)
    {
        if (productForUpdateDto is null)
            return BadRequest("ProductForUpdate object is null.");
        
        await _service.ProductService.UpdateProductForBrandAsync(
            brandId: id, productId, productForUpdateDto, brandTrackChanges: false, productTrackChanges: true);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBrand(Guid id)
    {
        await _service.BrandService.DeleteBrandAsync(brandId: id, trackChanges: false);

        return NoContent();
    }

    [HttpDelete("{id:guid}/products/{productId:guid}")]
    public async Task<IActionResult> DeleteBrandProduct(Guid id, Guid productId)
    {
        await _service.ProductService.DeleteProductForBrandAsync(brandId: id, productId, trackChanges: false);
        
        return NoContent();
    }
}
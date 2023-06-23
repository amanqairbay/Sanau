using Microsoft.AspNetCore.Mvc;
using Application.Common.DTOs;
using Application.Services;
using WebAPI.ModelBinders;
using WebAPI.ActionFilters;
using Application.Common.RequestFeatures;
using System.Text.Json;

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

#region GET methods

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
    public async Task<IActionResult> GetBrandProducts(Guid id, [FromQuery] ProductParameters productParameters)
    {
        var pagedResult = await _service.ProductService.GetPagedProductsForBrandAsync(brandId: id, productParameters, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

        return Ok(pagedResult.Products);
    }

    [HttpGet("{id:guid}/products/{productId:guid}", Name = "GetBrandProduct")]
    public async Task<IActionResult> GetBrandProduct(Guid id, Guid productId)
    {
        var product = await _service.ProductService
            .GetSingleProductForBrandAsync(brandId: id, productId, trackChanges: false);

        return Ok(product);
    }

#endregion GET methods

#region POST methods

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateBrand([FromBody] BrandForCreationDto brandForCreationDto)
    {
        var createdBrand = await _service.BrandService.CreateBrandAsync(brandForCreationDto);

        return CreatedAtRoute("BrandById", new { id = createdBrand.Id}, createdBrand);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateBrandCollection([FromBody]IEnumerable<BrandForCreationDto> brandForCreationDtos)
    {
        //TODO: Check the validate
        var result = await _service.BrandService.CreateBrandCollectionAsync(brandForCreationDtos);

        return CreatedAtRoute("BrandCollection", new { ids = result.BrandIds }, result.BrandDtos );
    }

    [HttpPost("{id:guid}/products")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateProductForBrand(Guid id, [FromBody]ProductForCreationDto productForCreationDto)
    {
        var createdProduct = await _service.ProductService.CreateProductForBrandAsync(id, productForCreationDto, trackChanges: false);
        
        return CreatedAtRoute("GetBrandProduct", new { id, productId = createdProduct.Id }, createdProduct);
    }

#endregion POST methods

#region PUT methods

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateBrand(Guid id, [FromBody]BrandForUpdateDto brandForUpdateDto)
    {
        await _service.BrandService.UpdateBrandAsync(brandId: id, brandForUpdateDto, trackChanges: true);

        return NoContent();
    }

    [HttpPut("{id:guid}/products/{productId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateBrandProduct(Guid id, Guid productId, [FromBody]ProductForUpdateDto productForUpdateDto)
    {
        await _service.ProductService.UpdateProductForBrandAsync(
            brandId: id, productId, productForUpdateDto, brandTrackChanges: false, productTrackChanges: true);

        return NoContent();
    }

#endregion PUT methods

#region DELETE methods

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

#endregion DELETE methods
}
using Microsoft.AspNetCore.Mvc;
using Application.Common.DTOs;
using Application.Services;
using WebAPI.ModelBinders;
using WebAPI.ActionFilters;
using Application.Common.RequestFeatures;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers;

public class BrandsController : BaseApiController
{
    private readonly IServiceManager _service;

    public BrandsController(IServiceManager service)
    {
        _service = service;
    }

    #region get methods

    /// <summary>
    /// Gets and returns a list of all brands.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the list of all brands.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAllBrands()
    {
        //throw new Exception("Exception");
        var brands = await _service.BrandService.GetAllBrandsAsync(trackChanges: false);
        return Ok(brands);
    }

    /// <summary>
    /// Gets brand by brand identifier.
    /// </summary>
    /// <param name="id">Brand identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    /// <response code="200">If the brand exists.</response>
    /// <response code="404">If the brand doesn't exist.</response>
    [HttpGet("{id:guid}", Name = "BrandById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBrand(Guid id)
    {
        var brand = await _service.BrandService.GetBrandByIdAsync(id, trackChanges: false);

        return Ok(brand);
    }

    /// <summary>
    /// Gets brands by brand identifiers.
    /// </summary>
    /// <param name="ids">Brand identifiers.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    /// <response code="200">If the brands exists.</response>
    /// <response code="404">If the brands do not exist.</response>
    [HttpGet("collection/({ids})", Name = "BrandCollection")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBrandsByIds(
        [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var brands = await _service.BrandService.GetBrandsByIdsAsync(brandIds: ids, trackChanges: false);

        return Ok(brands);
    }

    /// <summary>
    /// Gets paged products of a specific brand.
    /// </summary>
    /// <param name="id">Brand identifier.</param>
    /// <param name="productParameters">Product parameters.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products of a specific brand.
    /// </returns>
    /// <response code="200">If the brand exists.</response>
    /// <response code="400">If the products price range is invalid.</response>
    /// <response code="404">If the brand doesn't exist.</response>
    [HttpGet("{id:guid}/products")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPagedBrandProducts(Guid id, [FromQuery] ProductParameters productParameters)
    {
        var pagedResult = await _service.ProductService.GetPagedProductsForBrandAsync(brandId: id, productParameters, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

        return Ok(pagedResult.Products);
    }

    /// <summary>
    /// Gets the product of a specific brand.
    /// </summary>
    /// <param name="id">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product of a specific brand.
    /// </returns>
    /// <response code="200">If the brand exists.</response>
    /// <response code="404">If the brand doesn't exist.</response>
    [HttpGet("{id:guid}/products/{productId:guid}", Name = "GetBrandProduct")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBrandProduct(Guid id, Guid productId)
    {
        var product = await _service.ProductService
            .GetSingleProductForBrandAsync(brandId: id, productId, trackChanges: false);

        return Ok(product);
    }

    #endregion get methods

    #region post methods

    /// <summary>
    /// Creates the brand.
    /// </summary>
    /// <param name="brandForCreationDto">Data transfer object for brand creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the newly created brand.
    /// </returns>
    /// <response code="201">If the brand is created.</response>
    /// <response code="400">If the brand is null.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="422">If the brand is invalid.</response>
    [HttpPost]
    [Authorize(Roles = "Administrator,Manager")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateBrand([FromBody] BrandForCreationDto brandForCreationDto)
    {
        var createdBrand = await _service.BrandService.CreateBrandAsync(brandForCreationDto);

        return CreatedAtRoute("BrandById", new { id = createdBrand.Id}, createdBrand);
    }

    /// <summary>
    /// Creates the brands.
    /// </summary>
    /// <param name="brandForCreationDtos">Data transfers object for brand creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the newly created brand.
    /// </returns>
    /// <response code="201">If the brands are created.</response>
    /// <response code="400">If the brands are null.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="422">If the brands are invalid.</response>
    [HttpPost("collection")]
    [Authorize(Roles = "Administrator,Manager")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateBrandCollection([FromBody]IEnumerable<BrandForCreationDto> brandForCreationDtos)
    {
        //TODO: Check the validate
        var result = await _service.BrandService.CreateBrandCollectionAsync(brandForCreationDtos);

        return CreatedAtRoute("BrandCollection", new { ids = result.BrandIds }, result.BrandDtos );
    }

    /// <summary>
    /// Creates the product of a specific brand.
    /// </summary>
    /// <param name="id">Brand identifier.</param>
    /// <param name="productForCreationDto">Data transfer object for product creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the newly created product for a specific brand.
    /// </returns>
    /// <response code="201">If the product is created.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the brand doesn't exist.</response>
    /// <response code="422">If the product is invalid.</response>
    [HttpPost("{id:guid}/products")]
    [Authorize(Roles = "Administrator,Manager")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateProductForBrand(Guid id, [FromBody]ProductForCreationDto productForCreationDto)
    {
        var createdProduct = await _service.ProductService.CreateProductForBrandAsync(id, productForCreationDto, trackChanges: false);
        
        return CreatedAtRoute("GetBrandProduct", new { id, productId = createdProduct.Id }, createdProduct);
    }

    #endregion post methods

    #region put methods

    /// <summary>
    /// Updates the brand.
    /// </summary>
    /// <param name="id">Brand identifier.</param>
    /// <param name="brandForUpdateDto">Data transfer object for brand update.</param>
    /// <returns> A task that represents the asynchronous operation.</returns>
    /// <response code="204">If the brand is updated.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the brand doesn't exist.</response>
    /// <response code="422">If the brand is invalid.</response>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Administrator,Manager")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateBrand(Guid id, [FromBody]BrandForUpdateDto brandForUpdateDto)
    {
        await _service.BrandService.UpdateBrandAsync(brandId: id, brandForUpdateDto, trackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Updates the product of a specific brand.
    /// </summary>
    /// <param name="id">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <param name="productForUpdateDto">Data transfer object for update product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <response code="204">If the product is updated.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the brand or product doesn't exist.</response>
    /// <response code="422">If the product is invalid.</response>
    [HttpPut("{id:guid}/products/{productId:guid}")]
    [Authorize(Roles = "Administrator,Manager")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateBrandProduct(Guid id, Guid productId, [FromBody]ProductForUpdateDto productForUpdateDto)
    {
        await _service.ProductService.UpdateProductForBrandAsync(
            brandId: id, productId, productForUpdateDto, brandTrackChanges: false, productTrackChanges: true);

        return NoContent();
    }

    #endregion put methods

    #region delete methods

    /// <summary>
    /// Deletes the brand.
    /// </summary>
    /// <param name="id">Brand identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <response code="204">If the brand is deleted.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the brand or product doesn't exist.</response>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator,Manager")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBrand(Guid id)
    {
        await _service.BrandService.DeleteBrandAsync(brandId: id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Deletes the product for a specific brand.
    /// </summary>
    /// <param name="id">Brand identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <response code="204">If the product is deleted.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the brand or product doesn't exist.</response>
    [Authorize(Roles = "Administrator,Manager")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id:guid}/products/{productId:guid}")]
    public async Task<IActionResult> DeleteBrandProduct(Guid id, Guid productId)
    {
        await _service.ProductService.DeleteProductForBrandAsync(brandId: id, productId, trackChanges: false);
        
        return NoContent();
    }

    #endregion delete methods
}
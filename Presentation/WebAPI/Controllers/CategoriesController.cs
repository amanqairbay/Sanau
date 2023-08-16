using Application.Common.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers;

public class CategoriesController : BaseApiController
{
    private readonly IServiceManager _service;

    public CategoriesController(IServiceManager service)
    {
        _service = service;
    }

    #region GET methods

    /// <summary>
    /// Gets and returns a list of all categories.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the list of all categories.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
        return Ok(categories);
    }

    /// <summary>
    /// Gets category by identifier.
    /// </summary>
    /// <param name="id">Category identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the category.
    /// </returns>
    /// <response code="200">If the category exists.</response>
    /// <response code="404">If the category doesn't exist.</response>
    [HttpGet("{id:guid}", Name = "CategoryById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var category = await _service.CategoryService.GetCategoryByIdAsync(id, trackChanges: false);

        return Ok(category);
    }

    [HttpGet("{id:guid}/products")]
    public async Task<IActionResult> GetCategoryProducts(Guid id)
    {
        var products = await _service.ProductService.GetProductsForCategoryAsync(categoryId: id, trackChanges: false);
        return Ok(products);
    }

    /// <summary>
    /// Gets the product of a specific category.
    /// </summary>
    /// <param name="id">Category identifier.</param>
    /// <param name="productId">Product identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product of a specific category.
    /// </returns>
    /// <response code="200">If the category exists.</response>
    /// <response code="404">If the brand doesn't exist.</response>
    [HttpGet("{id:guid}/products/{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSingleProductForCategory(Guid id, Guid productId)
    {
        var product = await _service.ProductService
            .GetSingleProductForCategoryAsync(categoryId: id, productId, trackChanges: false);
        return Ok(product);
    }

    #endregion GET methods

    #region POST methods

    /// <summary>
    /// Creates the category.
    /// </summary>
    /// <param name="categoryForCreationDto">Data transfer object for category creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the newly created brand.
    /// </returns>
    /// <response code="201">If the category is created.</response>
    /// <response code="400">If the category is null.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="422">If the category is invalid.</response>
    [HttpPost]
    [Authorize(Roles = "Administrator,Manager")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto categoryForCreationDto)
    {
        var createdCategory = await _service.CategoryService.CreateCategoryAsync(categoryForCreationDto);

        return CreatedAtRoute("CategoryById", new { id = createdCategory.Id}, createdCategory);
    }

    #endregion POST methods
}
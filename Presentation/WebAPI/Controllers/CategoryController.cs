using Application.Common.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public CategoryController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        //throw new Exception("Exception");
        var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
        return Ok(categories);
    }

    [HttpGet("{id:guid}", Name = "CategoryById")]
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

    [HttpGet("{id:guid}/products/{productId:guid}")]
    public async Task<IActionResult> GetSingleProductForCategory(Guid id, Guid productId)
    {
        var product = await _service.ProductService
            .GetSingleProductForCategoryAsync(categoryId: id, productId, trackChanges: false);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto categoryForCreationDto)
    {
        if (categoryForCreationDto is null)
            return BadRequest("CategoryForCreationDto object is null");

        var createdCategory = await _service.CategoryService.CreateCategoryAsync(categoryForCreationDto);

        return CreatedAtRoute("CategoryById", new { id = createdCategory.Id}, createdCategory);
    }
}
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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var category = await _service.CategoryService.GetCategoryByIdAsync(id, trackChanges: false);

        return Ok(category);
    }
}
using Application.Services;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBrand(Guid id)
    {
        var brand = await _service.BrandService.GetBrandByIdAsync(id, trackChanges: false);

        return Ok(brand);
    }
}
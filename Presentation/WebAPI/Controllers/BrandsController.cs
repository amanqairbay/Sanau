using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IServiceManager _service;

    public BrandsController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetBrands()
    {
        throw new Exception("Exception");
        var brands = _service.BrandService.GetAllBrands(trackChanges: false);
        return Ok(brands);
    }
}
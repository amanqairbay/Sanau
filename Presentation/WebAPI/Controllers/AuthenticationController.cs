using System.Security.Claims;
using Application.Common.DTOs;
using Application.Services;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers;

public class AuthenticationController : BaseApiController
{
    private readonly IServiceManager _service;
    private readonly UserManager<AppUser> _userManager;

    public AuthenticationController(IServiceManager service, UserManager<AppUser> userManager)
    {
        _service = service;
        _userManager = userManager;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="userForRegistration">Data transfer object for register a new user.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <response code="201">If registration result is successful.</response>
    /// <response code="400">If registration result is not successful.</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        var result = await _service.AuthenticationService.RegisterUser(userForRegistration);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }

    /// <summary>
    /// Log in.
    /// </summary>
    /// <param name="userForAuthenticationDto">Data transfer object for user authentication.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <response code="200">If the user is logged in.</response>
    /// <response code="401">If the user is not authorized.</response>
    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDto)
    {
        if (!await _service.AuthenticationService.ValidateUser(userForAuthenticationDto))
            return Unauthorized();

        var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

        return Ok(tokenDto);
    }

    [HttpGet]
    public async Task<ActionResult<AppUser>> GetCurrentUser()
    {
        var email = HttpContext.User?.Claims?
            .FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        var user = await _userManager.FindByEmailAsync(email!);

        return new AppUser
        {
            Email = user!.Email,
            UserName = user.UserName
        };
    }
}
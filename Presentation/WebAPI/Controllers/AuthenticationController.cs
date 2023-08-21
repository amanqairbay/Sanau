using System.Security.Claims;
using Application.Common.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers;

public class AuthenticationController : BaseApiController
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDto)
    {
        if (!await _service.AuthenticationService.ValidateUser(userForAuthenticationDto))
            return Unauthorized();

        var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

        return Ok(tokenDto);
    }

    /// <summary>
    /// Gets current user.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains current user.
    /// </returns>
    /// <response code="200">If the user is exist.</response>
    /// <response code="401">If the user is not authorized.</response>
    [HttpGet("user")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetCurrentUser()
    {
        var user = await _service.AuthenticationService.GetCurrentUserAsync();

        return Ok(user); 
    }

    /// <summary>
    /// Gets the user's address.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the user's address.
    /// </returns>
    /// <response code="200">If the user's address is exist.</response>
    /// <response code="401">If the user is not authorized.</response>
    [HttpGet("address")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetUserAddress()
    {
        var address = await _service.AuthenticationService.GetUserAddressAsync();

        return Ok(address);
    }

    /// <summary>
    /// Updates the user's address.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the user's address.
    /// </returns>
    /// <response code="200">If the user's address is updated.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="200">If the user's address is not updated.</response>
    [HttpPut("address")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUserAddress(AddressDto addressDto)
    {
        var address = await _service.AuthenticationService.UpdateUserAddressAsync(addressDto);

        return Ok(address);
    }

    [HttpGet("emailexists")]
    [Authorize]
    public async Task<ActionResult<bool>> CheckEmailExists([FromQuery] string email)
    {
        return await _service.AuthenticationService.CheckEmailExistsAsync(email);
    }
}
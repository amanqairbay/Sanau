using Application.Common.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers;

public class TokenController : BaseApiController
{
    private readonly IServiceManager _service;

    public TokenController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Refreshes a token.
    /// </summary>
    /// <param name="tokenDto">Data transfer object for refreh a token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the refresh token.
    /// </returns>
    /// <response code="200">If the token refreshed.</response>
    /// <response code="400">If the token is null or does not match.</response>
    /// <response code="401">If the user is not authorized.</response>
    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);

        return Ok(tokenDtoToReturn);
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.DTOs.User;
using Core.Domain.Enums;
using Core.Services.ServiceClasses;
using Core.Services.ServiceExtension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserAuthenticationService _authenticationService;

    public AuthController(IUserAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserAuthentication userAuthentication)
    {
        var token = await _authenticationService.Login(userAuthentication);

        if (string.IsNullOrEmpty(token))
        {
            return BadRequest("UserName or Password is incorrect");
        }

        return Ok(new
        {
          Token = token
        });
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(UserRegistration userRegistration)
    {
        await _authenticationService.Register(userRegistration);
        return Ok("User registered successfully");
    }


    [HttpGet]
    [Route("User")]
    public async Task<ActionResult<UserGetDto>> GetCurrentUser()
    {
      try
      {
        var currentUser = await _authenticationService.GetCurrentUserAsync();
        return Ok(currentUser);
      }
      catch (UnauthorizedAccessException ex)
      {
        return Unauthorized(new { message = ex.Message });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { message = ex.Message });
      }
    }


}

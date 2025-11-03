using Microsoft.AspNetCore.Mvc;
using TaskSphere.API.DTOs.Auth;
using TaskSphere.API.Mappers;
using TaskSphere.API.Services.Interfaces;

namespace TaskSphere.API.Controllers
{
  [ApiController]
  [Route("api/auth")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterRequestDto registerDto)
    {
      var response = await _authService.RegisterAsync(registerDto.ToUser(), registerDto.Password);

      if (response == null)
        return BadRequest("User already exists.");

      return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequestDto loginDto)
    {
      var response = await _authService.LoginAsync(loginDto.Email, loginDto.Password);

      if (response == null)
        return Unauthorized("Invalid email or password.");

      return Ok(response);
    }
  }
}

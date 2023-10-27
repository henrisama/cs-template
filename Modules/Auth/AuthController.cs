using CSTemplate.DTOs;
using CSTemplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
  private readonly AuthService _authService;

  public AuthController(AuthService authService)
  {
    _authService = authService;
  }

  [HttpPost("Login")]
  public async Task<IActionResult> Login([FromBody] LoginDto obj)
  {
    IActionResult response = Unauthorized();
    var _token = await _authService.Authenticate(obj.Email, obj.Password);
    if (_token != null)
    {
      response = Ok(new { token = _token });
    }

    return response;
  }

  /* [HttpDelete("Logout")]
  public async Task<IActionResult> Logout([FromBody] LoginDto obj)
  {
    return NotFound();
  } */
}
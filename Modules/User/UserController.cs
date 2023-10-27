using CSTemplate.Auto;
using CSTemplate.DTOs;
using CSTemplate.Schemas;
using CSTemplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : AutoController<UserSchema, CreateUserDto, UpdateUserDto>
{
  private readonly UserService _userService;
  public UserController(UserService userService) : base(userService)
  {
    _userService = userService;
  }

  [HttpGet("email/{email}")]
  public virtual async Task<IActionResult> GetUserByEmail([FromRoute] string email)
  {
    var entity = await _userService.GetUserByEmail(email);
    return Ok(entity);
  }
}

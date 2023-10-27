using CSTemplate.Services;

namespace CSTemplate.Services;

public class AuthService
{
  private readonly UserService _userSevice;

  public AuthService(UserService userService)
  {
    _userSevice = userService;
  }

  public async Task<string?> Authenticate(string email, string password)
  {
    var user = await _userSevice.GetUserByEmail(email);

    if (user == null)
      return null;

    if (PasswordService.VerifyPassword(password, user.Password))
      return null;

    return TokenService.GenerateJSONWebToken(user);
  }
}
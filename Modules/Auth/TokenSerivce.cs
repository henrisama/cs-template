using System.Text;
using CSTemplate.Schemas;
// using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CSTemplate.Services;

public class TokenService
{
  public static string GenerateJSONWebToken(UserSchema user)
  {
    var securityKey = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET") ?? "helloworld"));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        Environment.GetEnvironmentVariable("JWT_ISSUER"),
        Environment.GetEnvironmentVariable("JWT_ISSUER"),
        null,
        expires: DateTime.Now.AddHours(2),
        signingCredentials: credentials);

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
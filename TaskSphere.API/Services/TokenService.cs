using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TaskSphere.API.Model;
using TaskSphere.API.Services.Interfaces;

namespace TaskSphere.API.Services
{
  public class TokenService : ITokenService
  {
    private readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
      _config = config;
    }

    public string GenerateToken(User user)
    {
      // 1. Get JWT Config
      var key = _config["Jwt:Key"];
      var issuer = _config["Jwt:Issuer"];
      var audience = _config["Jwt:Audience"];

      // 2. Define claims
      List<Claim> claims = [
        new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new(JwtRegisteredClaimNames.UniqueName, user.Username),
        new(JwtRegisteredClaimNames.Email, user.Email),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      ];

      // 3. Signing Credentials
      var signingCredentials = new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!)),
        SecurityAlgorithms.HmacSha512
      );

      // 4. Create Token
      var token = new JwtSecurityToken(
        issuer: issuer,
        audience: audience,
        claims: claims,
        expires: DateTime.UtcNow.AddDays(1),
        signingCredentials: signingCredentials
      );

      // 5. Return Token
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
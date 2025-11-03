using TaskSphere.API.Model;

namespace TaskSphere.API.Services.Interfaces
{
  public interface ITokenService
  {
    string GenerateToken(User user);
  }
}
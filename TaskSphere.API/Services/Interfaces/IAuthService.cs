using TaskSphere.API.DTOs.Auth;
using TaskSphere.API.Model;

namespace TaskSphere.API.Services.Interfaces
{
  public interface IAuthService
  {
    Task<AuthResponseDto?> RegisterAsync(User user, string password);
    Task<AuthResponseDto?> LoginAsync(string email, string password);
  }
}
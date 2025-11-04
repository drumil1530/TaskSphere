using System.Security.Claims;
using TaskSphere.API.Services.Interfaces;

namespace TaskSphere.API.Services
{
  public class UserContextService : IUserContextService
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
      var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

      if (string.IsNullOrEmpty(userId))
        throw new UnauthorizedAccessException("User ID not found in token.");

      return int.Parse(userId);
    }

    public string? GetUsername()
    {
      return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
    }

    public string? GetEmail()
    {
      return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
    }
  }
}

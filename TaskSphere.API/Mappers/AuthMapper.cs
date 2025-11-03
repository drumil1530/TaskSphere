using TaskSphere.API.DTOs.Auth;
using TaskSphere.API.Model;

namespace TaskSphere.API.Mappers
{
  public static class AuthMapper
  {
    public static User ToUser(this RegisterRequestDto dto)
    {
      return new User
      {
        Username = dto.Username,
        Email = dto.Email,
        // PasswordHash will be set in service
      };
    }

    public static AuthResponseDto ToAuthResponseDto(this User user, string token)
    {
      return new AuthResponseDto
      {
        Username = user.Username,
        Email = user.Email,
        Token = token
      };
    }
  }
}

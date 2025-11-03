namespace TaskSphere.API.DTOs.Auth
{
  public class AuthResponseDto
  {
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
  }
}
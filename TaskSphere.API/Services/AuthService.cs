using TaskSphere.API.DTOs.Auth;
using TaskSphere.API.Mappers;
using TaskSphere.API.Model;
using TaskSphere.API.Repositories.Interfaces;
using TaskSphere.API.Services.Interfaces;

namespace TaskSphere.API.Services
{
  public class AuthService : IAuthService
  {
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(
      IUserRepository userRepository,
      ITokenService tokenService
    )
    {
      _userRepository = userRepository;
      _tokenService = tokenService;
    }

    public async Task<AuthResponseDto?> LoginAsync(string email, string password)
    {
      // 1. Check if user exists
      var user = await _userRepository.GetByEmailAsync(email);
      if (user == null)
        return null;

      // 2. Check if password is correct  
      bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
      if (!validPassword)
        return null;

      // 3. Generate Token
      string token = _tokenService.GenerateToken(user);

      // 4. Return Token
      return user.ToAuthResponseDto(token);
    }

    public async Task<AuthResponseDto?> RegisterAsync(User user, string password)
    {
      // 1. Check if user already exists
      var existingUser = await _userRepository.GetByEmailAsync(user.Email);
      if (existingUser != null)
        return null;

      // 2. Hash Password
      string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
      user.PasswordHash = passwordHash;

      // 3. Save User
      await _userRepository.AddUserAsync(user);
      await _userRepository.SaveChangesAsync();

      // 4. Generate Token
      string token = _tokenService.GenerateToken(user);

      // 5. Return Token
      return user.ToAuthResponseDto(token);
    }
  }
}
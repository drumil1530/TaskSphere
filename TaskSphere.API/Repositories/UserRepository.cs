using Microsoft.EntityFrameworkCore;
using TaskSphere.API.Data;
using TaskSphere.API.Model;
using TaskSphere.API.Repositories.Interfaces;

namespace TaskSphere.API.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task AddUserAsync(User user)
    {
      await _context.Users.AddAsync(user);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task SaveChangesAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}
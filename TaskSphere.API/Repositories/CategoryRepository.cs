using Microsoft.EntityFrameworkCore;
using TaskSphere.API.Data;
using TaskSphere.API.Repositories.Interfaces;

namespace TaskSphere.API.Repositories
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<bool> ExistsForUserAsync(int categoryId, int userId)
    {
      return await _context.Categories
          .AnyAsync(c => c.Id == categoryId && c.UserId == userId);
    }
  }
}

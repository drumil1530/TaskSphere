using Microsoft.EntityFrameworkCore;

namespace TaskSphere.API.Data
{
  public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
  {

  }
}
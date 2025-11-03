using Microsoft.EntityFrameworkCore;
using TaskSphere.API.Data.Configurations;
using TaskSphere.API.Model;

namespace TaskSphere.API.Data
{
  public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
  {
    public DbSet<User> Users => Set<User>();
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();
    public DbSet<TaskOccurrence> TaskOccurrences => Set<TaskOccurrence>();
    public DbSet<TaskRepeatDay> TaskRepeatDays => Set<TaskRepeatDay>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new UserConfiguration());
      modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
      modelBuilder.ApplyConfiguration(new TaskOccurrenceConfiguration());
      modelBuilder.ApplyConfiguration(new TaskRepeatDayConfiguration());
      modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
  }
}
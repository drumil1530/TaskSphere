using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSphere.API.Model;

namespace TaskSphere.API.Data.Configurations
{
  public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
  {
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
      builder
        .HasOne(t => t.User)
        .WithMany(u => u.Tasks)
        .HasForeignKey(t => t.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      builder
        .HasOne(t => t.Category)
        .WithMany(c => c.Tasks)
        .HasForeignKey(t => t.CategoryId)
        .OnDelete(DeleteBehavior.SetNull);

      builder
        .Property(t => t.CreatedAt)
        .HasDefaultValue(DateTime.UtcNow);

      builder
        .Property(t => t.Title)
        .IsRequired()
        .HasMaxLength(100);

      builder
        .Property(t => t.Description)
        .HasMaxLength(500);

      builder
        .Property(t => t.ColorHex)
        .HasMaxLength(9);
    }
  }
}
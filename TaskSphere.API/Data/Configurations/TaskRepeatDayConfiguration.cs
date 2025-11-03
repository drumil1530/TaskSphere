using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSphere.API.Model;

namespace TaskSphere.API.Data.Configurations
{
  public class TaskRepeatDayConfiguration : IEntityTypeConfiguration<TaskRepeatDay>
  {
    public void Configure(EntityTypeBuilder<TaskRepeatDay> builder)
    {
      builder
        .HasIndex(r => new { r.TaskItemId, r.DayOfWeek })
        .IsUnique();

      builder
        .HasOne(r => r.TaskItem)
        .WithMany(t => t.RepeatDays)
        .HasForeignKey(r => r.TaskItemId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
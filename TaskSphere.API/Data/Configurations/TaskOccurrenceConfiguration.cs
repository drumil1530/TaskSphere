using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSphere.API.Model;

namespace TaskSphere.API.Data.Configurations
{
  public class TaskOccurrenceConfiguration : IEntityTypeConfiguration<TaskOccurrence>
  {
    public void Configure(EntityTypeBuilder<TaskOccurrence> builder)
    {
      builder
        .HasIndex(o => new { o.TaskItemId, o.Date })
        .IsUnique();

      builder
        .HasOne(o => o.TaskItem)
        .WithMany(t => t.Occurrences)
        .HasForeignKey(o => o.TaskItemId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
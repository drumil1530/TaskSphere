using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSphere.API.Model;

namespace TaskSphere.API.Data.Configurations
{
  public class CategoryConfiguration : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder
        .HasOne(c => c.User)
        .WithMany()
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Restrict);

      builder
        .Property(c => c.Name)
        .IsRequired()
        .HasMaxLength(50);

      builder
        .Property(c => c.Name)
        .IsRequired()
        .HasMaxLength(50);

      builder
        .Property(c => c.Icon)
        .HasMaxLength(100);

      builder
        .Property(c => c.ColorHex)
        .HasMaxLength(9); // e.g., "#RRGGBBAA"

    }
  }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSphere.API.Model;

namespace TaskSphere.API.Data.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder
        .Property(u => u.Username)
        .IsRequired()
        .HasMaxLength(50);

      builder
        .Property(u => u.Email)
        .IsRequired()
        .HasMaxLength(100);

      builder
        .HasIndex(u => u.Email)
        .IsUnique();

      builder
        .Property(u => u.PasswordHash)
        .IsRequired()
        .HasMaxLength(255);
    }
  }
}
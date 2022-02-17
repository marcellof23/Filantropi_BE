using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace if3250_2022_19_filantropi_backend.Models.Config
{
  public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("users");
      builder.HasKey(e => e.Email);
      builder.HasIndex(e => e.Email).IsUnique();

      builder.Property(b => b.Id)
          .IsRequired()
          .HasColumnName("id")
          .ValueGeneratedOnAdd();

      builder.Property(b => b.Email)
          .IsRequired()
          .HasColumnName("email");
    }
  }
}

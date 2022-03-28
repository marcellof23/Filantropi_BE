using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace if3250_2022_19_filantropi_backend.Models.Config
{
  public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("users");

      builder.Property(b => b.Id)
      .IsRequired()
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

      builder.Property(b => b.Name)
      .IsRequired()
      .HasColumnName("name");

      builder.Property(b => b.Email)
      .IsRequired()
      .HasColumnName("email");

      builder.Property(b => b.Password)
      .IsRequired()
      .HasColumnName("password");

      builder.Property(b => b.Role)
      .IsRequired()
       .HasConversion<string>();

      builder.Property(b => b.ImageUrl)
      .HasColumnName("image_url");

      builder.Property(b => b.DonationAmount)
      .IsRequired()
      .HasColumnName("donation_amount");

      builder.Property(b => b.Saldo)
      .IsRequired()
      .HasColumnName("saldo");
    }
  }
}

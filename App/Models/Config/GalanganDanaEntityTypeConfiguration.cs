using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace if3250_2022_19_filantropi_backend.Models.Config
{
  public class GalanganDanaTypeConfiguration : IEntityTypeConfiguration<GalanganDana>
  {
    public void Configure(EntityTypeBuilder<GalanganDana> builder)
    {
      builder.ToTable("galangan_dana");

      builder.Property(b => b.Id)
      .IsRequired()
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

      builder.Property(b => b.EventTitle)
      .IsRequired()
      .HasColumnName("title");

      builder.Property(b => b.Category)
      .IsRequired()
      .HasColumnName("category");

      builder.Property(b => b.TargetFund)
      .IsRequired()
      .HasColumnName("targetfund");

      builder.Property(b => b.Deadline)
      .IsRequired()
      .HasColumnName("deadline");

      builder.Property(b => b.ImageUrl)
      .HasColumnName("image_url");

      builder.Property(b => b.Description)
      .IsRequired()
      .HasColumnName("description");

      builder.Property(b => b.Status)
      .IsRequired()
     .HasConversion<string>();

      builder.Property(b => b.UserId)
      .IsRequired()
      .HasColumnName("user_id");
    }
  }
}

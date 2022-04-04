using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace if3250_2022_19_filantropi_backend.Models.Config
{
  public class TransactionHistoryTypeConfiguration : IEntityTypeConfiguration<TransactionHistory>
  {
    public void Configure(EntityTypeBuilder<TransactionHistory> builder)
    {
      builder.ToTable("transaction_history");

      builder.Property(b => b.Id)
      .IsRequired()
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

      builder.Property(b => b.GalanganDanaId)
      .IsRequired()
      .HasColumnName("galangan_dana_id");

      builder.Property(b => b.DonasiId)
      .IsRequired()
      .HasColumnName("donasi_id");

      builder.Property(b => b.Nominal)
      .IsRequired()
      .HasColumnName("nominal");

      builder.Property(b => b.Date)
      .HasColumnName("date");

    }
  }
}

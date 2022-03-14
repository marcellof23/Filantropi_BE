using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace if3250_2022_19_filantropi_backend.Models.Config
{
    public class DonasiEntityTypeConfiguration : IEntityTypeConfiguration<Donasi>
    {
        public void Configure(EntityTypeBuilder<Donasi> builder)
        {
            builder.ToTable("users");

            builder.Property(b => b.Id)
            .IsRequired()
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

            builder.Property(b => b.GalangDanaId)
            .IsRequired()
            .HasColumnName("galangDanaId");

            builder.Property(b => b.UserId)
            .IsRequired()
            .HasColumnName("userId");           

            builder.Property(b => b.Amount)
            .IsRequired()
            .HasColumnName("amount");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace if3250_2022_19_filantropi_backend.Models.Config
{
    public class DonasiEntityTypeConfiguration : IEntityTypeConfiguration<Donasi>
    {
        public void Configure(EntityTypeBuilder<Donasi> builder)
        {
            builder.ToTable("donasi");

            builder.Property(b => b.Id)
            .IsRequired()
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

            builder.Property(b => b.GalangDanaId)
            .IsRequired()
            .HasColumnName("galangdana_id");

            builder.Property(b => b.UserId)
            .IsRequired()
            .HasColumnName("user_id");           

            builder.Property(b => b.Amount)
            .IsRequired()
            .HasColumnName("amount");
        }
    }
}

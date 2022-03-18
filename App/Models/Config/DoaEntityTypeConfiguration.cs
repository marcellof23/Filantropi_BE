using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace if3250_2022_19_filantropi_backend.Models.Config
{
    public class DoaEntityTypeConfiguration : IEntityTypeConfiguration<Doa>
    {
        public void Configure(EntityTypeBuilder<Doa> builder)
        {
            builder.ToTable("doa");

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

            builder.Property(b => b.Description)
            .IsRequired()
            .HasColumnName("description");
        }
    }
}

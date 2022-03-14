
using if3250_2022_19_filantropi_backend.Models;
using if3250_2022_19_filantropi_backend.Models.Config;
using Microsoft.EntityFrameworkCore;

namespace if3250_2022_19_filantropi_backend.Data
{
  public class DataContext : DbContext, IDataContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<GalanganDana> GalanganDana { get; set; }
    public DbSet<Donasi> Donasi { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(GalanganDanaTypeConfiguration).Assembly);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonasiEntityTypeConfiguration).Assembly);
      
      /*
      modelBuilder.Entity<Donasi>()
        .HasOne(p => p.User)
        .WithOne(b => b.Donasi)
        .HasForeignKey("User");
      */

        /*
        modelBuilder.Entity<Donasi>()
                .HasOne(p => p.User)
                .WithMany(b => b.Donations)
                .HasForeignKey("UserId");
        */
    }
    #endregion
  }
}

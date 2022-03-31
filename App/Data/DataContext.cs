
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
    public DbSet<Doa> Doa { get; set; }

    public DbSet<TransactionHistory> TransactionHistory { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(GalanganDanaTypeConfiguration).Assembly);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonasiEntityTypeConfiguration).Assembly);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoaEntityTypeConfiguration).Assembly);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransactionHistoryTypeConfiguration).Assembly);
    }
    #endregion
  }
}

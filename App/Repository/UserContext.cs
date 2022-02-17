using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using if3250_2022_19_filantropi_backend.Models;
namespace if3250_2022_19_filantropi_backend.Repository
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
      ChangeTracker.DetectChanges();
      return base.SaveChanges();
    }
  }
}
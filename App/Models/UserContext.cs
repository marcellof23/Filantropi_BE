using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace if3250_2022_35_cakrawala_backend.Models
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
  }
}
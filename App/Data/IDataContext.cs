using if3250_2022_19_filantropi_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace if3250_2022_19_filantropi_backend.Data
{
  public interface IDataContext
  {
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  }
}

using if3250_2022_19_filantropi_backend.Models;
using System.Collections.Generic;

namespace if3250_2022_19_filantropi_backend.Repository
{
  public interface IUserRepository
  {
    Task<User> Get(int id);
    // Task<IEnumerable<User>> GetAll();
    Task Add(User user);
    Task Update(User user);
  }
}

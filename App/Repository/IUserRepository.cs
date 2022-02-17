using if3250_2022_19_filantropi_backend.Models;
using System.Collections.Generic;

namespace if3250_2022_19_filantropi_backend.Repository
{
  public interface IRepositoryUser
  {
    void AddUserRecord(User user);
    void UpdateUserRecord(User user);
    void DeleteUserRecord(int id);
    User GetUserSingleRecord(int id);
    List<User> GetUserRecords();
  }
}

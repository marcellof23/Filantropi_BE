using if3250_2022_19_filantropi_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace if3250_2022_19_filantropi_backend.Repository
{
  public class RepositoryUser : IRepositoryUser
  {
    private readonly UserContext _context;

    public RepositoryUser(UserContext context)
    {
      _context = context;
    }

    public void AddUserRecord(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    public void UpdateUserRecord(User user)
    {
      _context.Users.Update(user);
      _context.SaveChanges();
    }

    public void DeleteUserRecord(int id)
    {
      var entity = _context.Users.FirstOrDefault(t => t.Id == id);
      _context.Users.Remove(entity);
      _context.SaveChanges();
    }

    public User GetUserSingleRecord(int id)
    {
      return _context.Users.FirstOrDefault(t => t.Id == id);
    }

    public List<User> GetUserRecords()
    {
      return _context.Users.ToList();
    }
  }
}
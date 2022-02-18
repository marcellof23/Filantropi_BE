using Microsoft.EntityFrameworkCore;
using if3250_2022_19_filantropi_backend.Models;
using if3250_2022_19_filantropi_backend.Data;
using System.Collections.Generic;
using System.Linq;

namespace if3250_2022_19_filantropi_backend.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly IDataContext _context;
    public UserRepository(IDataContext context)
    {
      this._context = context;
    }
    public async Task Add(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
    }

    public async Task<User> Get(int id)
    {
      return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task Update(User user)
    {
      var itemToUpdate = await _context.Users.FindAsync(user.Id);
      if (itemToUpdate == null)
      {
        throw new NullReferenceException();
      }

      itemToUpdate.Name = user.Name;
      await _context.SaveChangesAsync();
    }
  }
}
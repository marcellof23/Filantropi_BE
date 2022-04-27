using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using if3250_2022_19_filantropi_backend.Data;
using if3250_2022_19_filantropi_backend.Models;
using if3250_2022_19_filantropi_backend.Helpers;

namespace if3250_2022_19_filantropi_backend.Services
{

  public interface IDoaService
  {
    Task<IEnumerable<Doa>> GetAll();
    Task<Doa> GetById(long id);

    Task<IEnumerable<Doa>> GetByGalangDanaId(long id);
    Task<int> CreateDoa(Doa doa);
    Task<int> UpdateDoa(long id, Doa doa);
    DataContext GetDataContext();
    bool DoaExists(long id);
  }

  public class DoaService : IDoaService
  {
    private readonly DataContext _context;
    private readonly AppSettings _appSettings;

    public DoaService(IOptions<AppSettings> appSettings, DataContext context)
    {
      _appSettings = appSettings.Value;
      _context = context;
    }

    public async Task<IEnumerable<Doa>> GetAll()
    {
      return await _context.Doa.ToListAsync();
    }

    public async Task<Doa> GetById(long id)
    {
      var doa = await _context.Doa.FindAsync(id);

      if (doa == null)
      {
        return null;
      }
      return doa;
    }

    public async Task<IEnumerable<Doa>> GetByGalangDanaId(long id)
    {
      var query = from s in _context.Doa
                  select s;

      query = query.Where(s => s.GalangDanaId == id);

      return await query.ToListAsync();
    }

    public async Task<int> CreateDoa(Doa doa)
    {
      _context.Doa.Add(doa);
      return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateDoa(long id, Doa doa)
    {
      var local = _context.Set<Doa>()
      .Local
      .FirstOrDefault(entry => entry.Id.Equals(id));

      // check if local is not null 
      if (local != null)
      {
        _context.Entry(local).State = EntityState.Detached;
      }

      _context.Entry(doa).State = EntityState.Modified;

      return await _context.SaveChangesAsync();
    }

    public bool DoaExists(long id)
    {
      Console.WriteLine(id);
      return _context.Doa.Any(e => e.Id == id);
    }

    //Register dengan add
    public DataContext GetDataContext()
    {
      return _context;
    }
  }
}

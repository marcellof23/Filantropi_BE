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

  public interface IGalanganDanaService
  {
    Task<IEnumerable<GalanganDana>> GetAll();
    Task<IEnumerable<GalanganDana>> GetByQuery(long userId, string status);
    Task<GalanganDana> GetById(long id);
    Task<int> CreateGalanganDana(GalanganDana galangandana);
    DataContext GetDataContext();

    Task<int> UpdateGalanganDana(long id, GalanganDana galangandana);
    bool GalanganDanaExists(long id);
  }

  public class GalanganDanaService : IGalanganDanaService
  {
    private readonly DataContext _context;
    private readonly AppSettings _appSettings;

    public GalanganDanaService(IOptions<AppSettings> appSettings, DataContext context)
    {
      _appSettings = appSettings.Value;
      _context = context;
    }

    public async Task<IEnumerable<GalanganDana>> GetByQuery(long userId, string status)
    {

      var query = from s in _context.GalanganDana
                  select s;

      query = query.OrderByDescending(s => s.Deadline);

      if (userId != 0)
      {
        query = query.Where(s => s.UserId == userId);
      }

      if (status != "")
      {
        query.Where(s => s.Status.Equals(status));
      }

      return await query.ToListAsync();
    }

    public async Task<IEnumerable<GalanganDana>> GetAll()
    {
      return await _context.GalanganDana.ToListAsync();
    }

    public async Task<GalanganDana> GetById(long id)
    {
      var galangandana = await _context.GalanganDana.FindAsync(id);

      if (galangandana == null)
      {
        return null;
      }
      return galangandana;
    }

    public async Task<int> CreateGalanganDana(GalanganDana galangandana)
    {
      _context.GalanganDana.Add(galangandana);
      return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateGalanganDana(long id, GalanganDana galangandana)
    {
      var local = _context.Set<GalanganDana>()
   .Local
   .FirstOrDefault(entry => entry.Id.Equals(id));

      // check if local is not null 
      if (local != null)
      {
        _context.Entry(local).State = EntityState.Detached;
      }

      _context.Entry(galangandana).State = EntityState.Modified;

      return await _context.SaveChangesAsync();
    }

    public bool GalanganDanaExists(long id)
    {
      Console.WriteLine(id);
      return _context.GalanganDana.Any(e => e.Id == id);
    }

    //Register dengan add
    public DataContext GetDataContext()
    {
      return _context;
    }
  }
}

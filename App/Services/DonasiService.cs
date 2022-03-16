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

  public interface IDonasiService
  {
    Task<IEnumerable<Donasi>> GetAll();
    Task<Donasi> GetById(long id);
    Task<int> CreateDonasi(Donasi donasi);
    DataContext GetDataContext();
    
  }

  public class DonasiService : IDonasiService
    {
    private readonly DataContext _context;
    private readonly AppSettings _appSettings;

    public DonasiService(IOptions<AppSettings> appSettings, DataContext context)
    {
      _appSettings = appSettings.Value;
      _context = context;
    }

    public async Task<IEnumerable<Donasi>> GetAll()
    {
      return await _context.Donasi.ToListAsync();
    }

    public async Task<Donasi> GetById(long id)
    {
      var donasi = await _context.Donasi.FindAsync(id);

      if (donasi == null)
      {
        return null;
      }
      return donasi;
    }

    public async Task<int> CreateDonasi(Donasi donasi)
    {
      _context.Donasi.Add(donasi);
      return await _context.SaveChangesAsync();
    }

    //Register dengan add
    public DataContext GetDataContext()
    {
      return _context;
    }
  }
}

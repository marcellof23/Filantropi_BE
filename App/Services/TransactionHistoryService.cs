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

  public interface ITransactionHistoryService
  {
    Task<IEnumerable<TransactionHistory>> GetAll();
    Task<TransactionHistory> GetById(long id);
  }

  public class TransactionHistoryService : ITransactionHistoryService
  {
    private readonly DataContext _context;
    // transaction_historys hardcoded for simplicity, store in a db with hashed passwords in production applications

    private readonly AppSettings _appSettings;

    public TransactionHistoryService(IOptions<AppSettings> appSettings, DataContext context)
    {
      _appSettings = appSettings.Value;
      _context = context;
    }

    public async Task<IEnumerable<TransactionHistory>> GetAll()
    {
      return await _context.TransactionHistory.ToListAsync();
    }

    public async Task<TransactionHistory> GetById(long id)
    {
      var transaction_history = await _context.TransactionHistory.FindAsync(id);

      if (transaction_history == null)
      {
        return null;
      }
      return transaction_history;
    }
  }
}

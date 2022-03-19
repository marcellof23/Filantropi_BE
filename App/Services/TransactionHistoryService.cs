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
    Task<int> CreateTransactionHistory(TransactionHistory transaction_history);

    Task<int> UpdateTransactionHistory(long id, TransactionHistory transaction_history);

    Task<int> DeleteTransactionHistory(long id);
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

    public async Task<int> CreateTransactionHistory(TransactionHistory transaction_history)
    {
      _context.TransactionHistory.Add(transaction_history);
      return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateTransactionHistory(long id, TransactionHistory transaction_history)
    {
      var local = _context.Set<TransactionHistory>()
   .Local
   .FirstOrDefault(entry => entry.Id.Equals(id));

      // check if local is not null 
      if (local != null)
      {
        _context.Entry(local).State = EntityState.Detached;
      }

      _context.Entry(transaction_history).State = EntityState.Modified;

      return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteTransactionHistory(long id)
    {

      var transaction_history = await _context.TransactionHistory.FindAsync(id);
      if (transaction_history == null)
      {
        return 0;
      }

      var isRemoved = _context.TransactionHistory.Remove(transaction_history);

      return await _context.SaveChangesAsync();
    }
  }
}

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

  using BCrypt = BCrypt.Net.BCrypt;
  public interface IUserService
  {
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(long id);
    Task<int> CreateUser(User user);
    DataContext GetDataContext();

    Task<int> UpdateUser(long id, User user);

    Task<int> DeleteUser(long id);
    bool UserExists(long id);

    bool EmailExists(string email);
  }

  public class UserService : IUserService
  {
    private readonly DataContext _context;
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings, DataContext context)
    {
      _appSettings = appSettings.Value;
      _context = context;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
      var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
      // return null if user not found
      if (user == null || !BCrypt.Verify(model.Password, user.Password)) return null;

      // authentication successful so generate jwt token
      var token = generateJwtToken(user);

      return new AuthenticateResponse(user.WithoutPassword(), token);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
      return await _context.Users.Where(f => f.Role != Role.Blocked).ToListAsync();
    }

    public async Task<User> GetById(long id)
    {
      var user = await _context.Users.FindAsync(id);

      if (user == null)
      {
        return null;
      }
      return user;
    }

    public async Task<int> CreateUser(User user)
    {
      string passwordHash = BCrypt.HashPassword(user.Password);
      user.Password = passwordHash;
      _context.Users.Add(user);
      return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateUser(long id, User user)
    {
      user.Password = BCrypt.HashPassword(user.Password);
      _context.Users.Update(user);
      return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteUser(long id)
    {

      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return 0;
      }

      var isRemoved = _context.Users.Remove(user);

      return await _context.SaveChangesAsync();
    }

    public bool UserExists(long id)
    {
      Console.WriteLine(id);
      return _context.Users.Any(e => e.Id == id);
    }

    public bool EmailExists(string email)
    {
      return _context.Users.Any(e => e.Email == email);
    }

    //Register dengan add
    public DataContext GetDataContext()
    {
      return _context;
    }

    // helper methods

    private string generateJwtToken(User user)
    {
      // generate token that is valid for 7 days
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

      var claim_email = new Claim("email", user.Email.ToString());
      var claim_id = new Claim("id", user.Id.ToString());

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { claim_id, claim_email }),
        Expires = DateTime.UtcNow.AddMinutes(10),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

  }
}

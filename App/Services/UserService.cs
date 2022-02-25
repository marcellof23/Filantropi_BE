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

  public interface IUserService
  {
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(long id);
    DataContext GetDataContext();

    Task<User> UpdateUser(User user);

    bool UserExists(long id);
  }

  public class UserService : IUserService
  {
    private readonly DataContext _context;
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
    {
        new User { Id = 1, Email = "test@gmail.com", Password = "test" }
    };

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings, DataContext context)
    {
      _appSettings = appSettings.Value;
      _context = context;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
      var user = _context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
      // return null if user not found
      if (user == null) return null;

      // authentication successful so generate jwt token
      var token = generateJwtToken(user);

      return new AuthenticateResponse(user, token);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
      return await _context.Users.ToListAsync();
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

    public async Task<User> UpdateUser(User user)
    {
      // if (!UserExists(id))
      // {
      //   return user;
      // }

      return user;

      // _context.Entry(user).State = EntityState.Modified;
      // try
      // {
      //   _context.Update(student);
      //   await _context.SaveChangesAsync();
      //   return RedirectToAction(nameof(Index));
      // }
      // catch (DbUpdateException /* ex */)
      // {
      //   //Log the error (uncomment ex variable name and write a log.)
      //   ModelState.AddModelError("", "Unable to save changes. " +
      //       "Try again, and if the problem persists, " +
      //       "see your system administrator.");
      // }

      // return user;
    }

    public bool UserExists(long id)
    {
      return _context.Users.Any(e => e.Id == id);
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
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}

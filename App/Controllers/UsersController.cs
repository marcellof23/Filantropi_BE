using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using if3250_2022_19_filantropi_backend.Models;
using if3250_2022_19_filantropi_backend.Data;
using if3250_2022_19_filantropi_backend.Helpers;
using if3250_2022_19_filantropi_backend.Services;

namespace if3250_2022_19_filantropi_backend.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService _userService;
    private readonly DataContext _context;

    public UsersController(IUserService userService)
    {
      _userService = userService;
      _context = userService.GetDataContext();
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
      var response = _userService.Authenticate(model);

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }

    // GET: api/Users
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
      var users = await _userService.GetAll();
      return Ok(users);
    }

    // GET: api/Users/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(long id)
    {
      var users = await _userService.GetById(id);
      return Ok(users);
    }

    // PUT: api/Users/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(long id, User user)
    {
      var user_updated = await _userService.UpdateUser(user);

      if (user_updated == null)
      {
        return BadRequest();
      }

      return Ok(user_updated);

      // try
      // {
      //   if (id != user.Id)
      //     return BadRequest("Employee ID mismatch");

      //   var UserToUpdate = _userService.UserExists(id);

      //   if (UserToUpdate == null)
      //     return NotFound($"Employee with Id = {id} not found");

      //   //return await _userService.UpdateUser(user);
      // }
      // catch (Exception)
      // {
      //   return StatusCode(StatusCodes.Status500InternalServerError,
      //       "Error updating data");
      // }
    }

    // POST: api/Users
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
      if (EmailExists(user.Email))
      {
        return BadRequest(new { message = "Email exists" });
      }
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return Ok(user);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool UserExists(long id)
    {
      return _context.Users.Any(e => e.Id == id);
    }
    private bool EmailExists(string email)
    {
      return _context.Users.Any(e => e.Email == email);
    }
  }
}

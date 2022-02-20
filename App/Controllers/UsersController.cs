#nullable disable
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

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
      var response = _userService.Authenticate(model);

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }

    // // GET: api/Users
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    // {
    //   return await _context.Users.ToListAsync();
    // }

    // GET: api/Users/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(long id)
    {
      var users = await _userService.GetById(id);
      return Ok(users);
    }

    // // PUT: api/Users/5
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutUser(long id, User user)
    // {
    //   if (id != user.Id)
    //   {
    //     return BadRequest();
    //   }

    //   _context.Entry(user).State = EntityState.Modified;

    //   try
    //   {
    //     await _context.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!UserExists(id))
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       throw;
    //     }
    //   }

    //   return NoContent();
    // }

    // // POST: api/Users
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPost]
    // public async Task<ActionResult<User>> PostUser(User user)
    // {
    //   _context.Users.Add(user);
    //   await _context.SaveChangesAsync();

    //   return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    // }

    // // DELETE: api/Users/5
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteUser(long id)
    // {
    //   var user = await _context.Users.FindAsync(id);
    //   if (user == null)
    //   {
    //     return NotFound();
    //   }

    //   _context.Users.Remove(user);
    //   await _context.SaveChangesAsync();

    //   return NoContent();
    // }

    // private bool UserExists(long id)
    // {
    //   return _context.Users.Any(e => e.Id == id);
    // }
  }
}

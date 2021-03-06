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

    // GET: api/user
    [Authorize(Role.Admin)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
      var users = await _userService.GetAll();
      return Ok(users);
    }

    // GET: api/user/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(long id)
    {
      var users = await _userService.GetById(id);
      if (users == null)
      {
        return NotFound();
      }
      if (users.Role == Role.Blocked)
      {
        return BadRequest(new { message = "User blocked" });
      }
      else
      {
        return Ok(users);
      }

    }

    // PUT: api/user/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize(Role.User)]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(long id, [FromBody] User user)
    {
      if (id != user.Id)
      {
        return BadRequest();
      }

      var user_updated = await _userService.UpdateUser(id, user);
      if (user_updated == 0)
      {
        return BadRequest();
      }
      return Ok("Updated successfully");
    }

    // POST: api/user
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<User>> RegisterUser(User user)
    {
      user.Role = Role.User;
      if (_userService.EmailExists(user.Email))
      {
        return BadRequest(new { message = "Email exists" });
      }
      var user_created = await _userService.CreateUser(user);
      if (user_created != 0)
      {
        return Ok(user.WithoutPassword());
      }
      return BadRequest(new { message = "Please check your entity request" });
    }

    // DELETE: api/user/5
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
      var user_deleted = await _userService.DeleteUser(id);
      if (user_deleted == 0)
      {
        return BadRequest(new { message = "Please check your request id" });
      }

      return Ok(new { message = "User removed successfully" });
    }

    //Post api/user/block/{id}
    [Authorize(Role.Admin)]
    [HttpGet("block/{id}")]
    public async Task<ActionResult<IEnumerable<User>>> BlockUser(long id)
    {
      var user = await _userService.GetById(id);
      user.Role = Role.Blocked;
      await PutUser(id, user);
      return Ok(user);
    }
  }
}

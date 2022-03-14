using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using if3250_2022_19_filantropi_backend.Models;
using if3250_2022_19_filantropi_backend.Services;
using if3250_2022_19_filantropi_backend.Controllers;

namespace Tests
{
  public class UserTest
  {
    public UserTest()
    {
    }




    [Fact]
    public async Task GetUserById()
    {
      var mock = new Mock<IUserService>();

      var user = new User()
      {
        Id = 3,
        Name = "testing4",
        Email = "testing@gmail.com",
        Password = "punten12345",
        Role = "user",
        ImageUrl = null,
        DonationAmount = 1102,
      };

      mock.Setup(p => p.GetById(3)).ReturnsAsync(user);
      UsersController u = new UsersController(mock.Object);
      var result = await u.GetUser(3);

      Assert.IsType<OkResult>(result);

      Assert.NotNull(result);
    }
  }
}
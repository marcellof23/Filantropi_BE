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
    public async Task GetUserByIdTest()
    {
      var mock = new Mock<IUserService>();

      var user = new User()
      {
        Id = 3,
        Name = "testing4",
        Email = "testing@gmail.com",
        Password = "punten12345",
        Role = Role.User,
        ImageUrl = null,
        DonationAmount = 1102,
      };

      mock.Setup(p => p.GetById(3)).ReturnsAsync(user);
      UsersController u = new UsersController(mock.Object);
      var result = await u.GetUser(3);

      Assert.IsType<OkObjectResult>(result);
      Assert.NotNull(result);
    }

    [Fact]
    public async Task GetUsersTest()
    {
      var mock = new Mock<IUserService>();

      var user1 = new User()
      {
        Id = 1,
        Name = "testing4",
        Email = "testing@gmail.com",
        Password = "punten12345",
        Role = Role.User,
        ImageUrl = null,
        DonationAmount = 1102,
      };

      var user2 = new User()
      {
        Id = 1,
        Name = "testing5",
        Email = "testing2@gmail.com",
        Password = "punten12345",
        Role = Role.User,
        ImageUrl = null,
        DonationAmount = 1102,
      };

      var users = new User[2] { user1, user2 };

      mock.Setup(p => p.GetAll()).ReturnsAsync(users);
      UsersController u = new UsersController(mock.Object);
      var result = await u.GetUsers();

      Assert.IsType<OkObjectResult>(result.Result);
      Assert.NotNull(result);
    }

    [Fact]
    public async Task CreateUserSuccessTest()
    {
      var mock = new Mock<IUserService>();

      var user = new User()
      {
        Name = "testing4",
        Email = "afafafaf@gmail.com",
        Password = "punten12345",
        Role = Role.User,
        DonationAmount = 1102,
      };

      mock.Setup(p => p.CreateUser(user)).ReturnsAsync(1);
      UsersController u = new UsersController(mock.Object);
      var result = await u.RegisterUser(user);

      Assert.IsType<OkObjectResult>(result.Result);
      Assert.NotNull(result);
    }

    [Fact]
    public async Task CreateUserFailTest()
    {
      var mock = new Mock<IUserService>();

      var user = new User()
      {
        Name = "testing4",
        Password = "punten12345",
        Role = Role.User,
        DonationAmount = 1102,
      };

      mock.Setup(p => p.CreateUser(user)).ReturnsAsync(0);
      UsersController u = new UsersController(mock.Object);
      var result = await u.RegisterUser(user);

      Assert.IsType<BadRequestObjectResult>(result.Result);
      Assert.NotNull(result);
    }

    [Fact]
    public async Task DeleteUserTest()
    {
      var mock = new Mock<IUserService>();

      mock.Setup(p => p.DeleteUser(1)).ReturnsAsync(1);
      UsersController u = new UsersController(mock.Object);
      var result = await u.DeleteUser(1);

      Assert.IsType<OkObjectResult>(result);
      Assert.NotNull(result);
    }
  }
}
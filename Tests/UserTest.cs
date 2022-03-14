using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

using Microsoft.EntityFrameworkCore;
using if3250_2022_19_filantropi_backend.Models;
using if3250_2022_19_filantropi_backend.Data;
using if3250_2022_19_filantropi_backend.Helpers;
using if3250_2022_19_filantropi_backend.Services;
using if3250_2022_19_filantropi_backend.Controllers;

namespace Tests
{
  public class UserTest
  {
    public UserTest()
    {
    }

    public Mock<IUserService> mock = new Mock<IUserService>();

    [Fact]
    public async void GetUserById()
    {
      mock.Setup(p => p.GetById(3));
      UsersController u = new UsersController(mock.Object);
      var result = await u.GetUser(3);

      Assert.NotNull(result);
      var res = result.Result as OkObjectResult;
      Assert.Equal(200, res.StatusCode);
    }
  }
}
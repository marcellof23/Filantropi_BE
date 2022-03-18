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
  public class GalangDanaTest
    {
    public GalangDanaTest()
    {
    }

    [Fact]
    public async Task GetGalangDanaByIdTest()
    {
      var mock = new Mock<IGalanganDanaService>();

      var galangDana = new GalanganDana()
      {
        Id = 3,
        EventTitle = "AcaraGalang1",
        Category = "Pendidikan",
        TargetFund = 1000000,
        Deadline = System.DateTime.Now,
        Description = "Test event",
        ImageUrl = "https://4.bp.blogspot.com/-XegwgOFLGsY/VYS-dEgxTmI/AAAAAAAAumI/vS-SyCItdYk/w1200-h630-p-k-no-nu/thumbnail_saikoro.jpg"
      };

      mock.Setup(p => p.GetById(3)).ReturnsAsync(galangDana);
      GalanganDanaController u = new GalanganDanaController(mock.Object);
      var result = await u.GetGalanganDana(3);

      Assert.IsType<OkObjectResult>(result);
      Assert.NotNull(result);
    }

    [Fact]
    public async Task GetGalangDanaTest()
    {
      var mock = new Mock<IGalanganDanaService>();

    var galangDana1 = new GalanganDana()
    {
        Id = 3,
        EventTitle = "AcaraGalang1",
        Category = "Pendidikan",
        TargetFund = 1000000,
        Deadline = System.DateTime.Now,
        Description = "Test event",
        ImageUrl = "https://4.bp.blogspot.com/-XegwgOFLGsY/VYS-dEgxTmI/AAAAAAAAumI/vS-SyCItdYk/w1200-h630-p-k-no-nu/thumbnail_saikoro.jpg"
    };

    var galangDana2 = new GalanganDana()
    {
        Id = 4,
        EventTitle = "AcaraGalang2",
        Category = "Pendidikan",
        TargetFund = 1000000,
        Deadline = System.DateTime.Now,
        Description = "Test event",
        ImageUrl = "https://4.bp.blogspot.com/-XegwgOFLGsY/VYS-dEgxTmI/AAAAAAAAumI/vS-SyCItdYk/w1200-h630-p-k-no-nu/thumbnail_saikoro.jpg"
    };

      var galanganDanas = new GalanganDana[2] { galangDana1, galangDana2 };

      mock.Setup(p => p.GetAll()).ReturnsAsync(galanganDanas);
      GalanganDanaController u = new GalanganDanaController(mock.Object);
      var result = await u.GetGalanganDanas();

      Assert.IsType<OkObjectResult>(result.Result);
      Assert.NotNull(result);
    }

    [Fact]
    public async Task CreateGalangDanaSuccessTest()
    {
      var mock = new Mock<IGalanganDanaService>();

    var galangDana = new GalanganDana()
    {
        EventTitle = "AcaraGalang1",
        Category = "Pendidikan",
        TargetFund = 1000000,
        Deadline = System.DateTime.Now,
        Description = "Test event",
        ImageUrl = "https://4.bp.blogspot.com/-XegwgOFLGsY/VYS-dEgxTmI/AAAAAAAAumI/vS-SyCItdYk/w1200-h630-p-k-no-nu/thumbnail_saikoro.jpg"
    };

      mock.Setup(p => p.CreateGalanganDana(galangDana)).ReturnsAsync(1);
      GalanganDanaController u = new GalanganDanaController(mock.Object);
      var result = await u.PostGalangDana(galangDana);

      Assert.IsType<OkObjectResult>(result.Result);
      Assert.NotNull(result);
    }
  }
}
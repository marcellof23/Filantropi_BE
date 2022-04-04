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
  [Route("api/galang_dana")]
  [ApiController]
  public class GalanganDanaController : ControllerBase
  {
    private IGalanganDanaService _galanganDanaService;

    public GalanganDanaController(IGalanganDanaService galanganDanaService)
    {
      _galanganDanaService = galanganDanaService;
    }

    //Get api/galang_dana
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<GalanganDana>>> GetGalanganDanas()
    // {
    //   var galanganDana = await _galanganDanaService.GetAll();
    //   return Ok(galanganDana);
    // }

    //Get api/galang_dana
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GalanganDana>>> GetGalanganDanasByQuery(long userId, string status)
    {
      var galanganDana = await _galanganDanaService.GetByQuery(userId, status);
      return Ok(galanganDana);
    }

    //Get api/galang_dana/id
    [HttpGet("{id}")]
    public async Task<ActionResult> GetGalanganDana(long id)
    {
      var galangan_dana = await _galanganDanaService.GetById(id);

      if (galangan_dana == null)
      {
        return NotFound();
      }

      return Ok(galangan_dana);
    }

    // PUT: api/GalanganDanas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGalanganDana(long id, GalanganDana galangan_dana)
    {
      if (id != galangan_dana.Id)
      {
        return BadRequest();
      }

      try
      {
        var galangan_dana_updated = await _galanganDanaService.UpdateGalanganDana(id, galangan_dana);
        if (galangan_dana_updated == 0)
        {
          return BadRequest();
        }
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_galanganDanaService.GalanganDanaExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return Ok(galangan_dana);
    }

    // POST: api/galang_dana
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<GalanganDana>> PostGalangDana(GalanganDana galangan_dana)
    {
      var galangan_dana_created = await _galanganDanaService.CreateGalanganDana(galangan_dana);
      if (galangan_dana_created != 0)
      {
        return Ok(galangan_dana);
      }
      return BadRequest(new { message = "Please check your entity request" });
    }
  }
}

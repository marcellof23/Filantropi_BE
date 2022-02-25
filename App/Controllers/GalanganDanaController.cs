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
    private readonly DataContext _context;

    public GalanganDanaController(DataContext context)
    {
      _context = context;
    }

    //Get api/galang_dana
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GalanganDana>>> GetGalanganDanas()
    {
      return await _context.GalanganDana.ToListAsync();
    }

    //Get api/galang_dana/id
    [HttpGet("{id}")]
    public async Task<ActionResult<GalanganDana>> GetGalanganDana(long id)
    {
      var galangan_dana = await _context.GalanganDana.FindAsync(id);

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

      _context.Entry(galangan_dana).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GalangDanaExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/galang_dana
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<GalanganDana>> PostGalangDana(GalanganDana galangan_dana)
    {
      _context.GalanganDana.Add(galangan_dana);
      await _context.SaveChangesAsync();
      return Ok(galangan_dana);
    }

    private bool GalangDanaExists(long id)
    {
      return _context.GalanganDana.Any(e => e.Id == id);
    }
  }
}

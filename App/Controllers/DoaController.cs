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
  [Route("api/doa")]
  [ApiController]
  public class DoaController : ControllerBase
  {
    private IDoaService _doaService;

    public DoaController(IDoaService doaService)
    {
      _doaService = doaService;
    }

    //Get api/doa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doa>>> GetListDoa()
    {
      var doa = await _doaService.GetAll();
      return Ok(doa);
    }

    //Get api/doa/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Doa>> GetDoa(long id)
    {
      var doa = await _doaService.GetById(id);

      if (doa == null)
      {
        return NotFound();
      }

      return Ok(doa);
    }

    //Get api/doa/{id}
    [HttpGet("galang-dana/{id}")]
    public async Task<ActionResult<Doa>> GetDoaByGalangDanaID(long id)
    {
      var doa = await _doaService.GetByGalangDanaId(id);

      if (doa == null)
      {
        return NotFound();
      }

      return Ok(doa);
    }

    // POST: api/doa
    [HttpPost]
    public async Task<ActionResult<Doa>> PostDoa(Doa doa)
    {
      await _doaService.CreateDoa(doa);
      return Ok(doa);
    }

    // PUT: api/doa/{id}
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDoa(long id, Doa doa)
    {
      if (id != doa.Id)
      {
        return BadRequest();
      }

      try
      {
        var doa_updated = await _doaService.UpdateDoa(id, doa);
        if (doa_updated == 0)
        {
          return BadRequest();
        }
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_doaService.DoaExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return Ok(doa);
    }
  }
}

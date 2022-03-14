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
    [Route("api/donasi")]
    [ApiController]
    public class DonasiController : ControllerBase
    {
        private readonly DataContext _context;

        public DonasiController(DataContext context)
        {
            _context = context;
        }

        //Get api/donasi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donasi>>> GetListDonasi()
        {
            return await _context.Donasi.ToListAsync();
        }

        //Get api/donasi/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Donasi>> GetDonasi(long id)
        {
            var donasi = await _context.Donasi.FindAsync(id);

            if (donasi == null)
            {
                return NotFound();
            }

            return Ok(donasi);
        }

        // POST: api/donasi
        [HttpPost]
        public async Task<ActionResult<Donasi>> PostUser(Donasi donasi)
        {
            _context.Donasi.Add(donasi);
            await _context.SaveChangesAsync();
            return Ok(donasi);
        }
    }
}

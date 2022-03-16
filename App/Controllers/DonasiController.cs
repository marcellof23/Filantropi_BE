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
        private IDonasiService _donasiService;

        public DonasiController(IDonasiService donasiService)
        {
            _donasiService = donasiService;
        }

        //Get api/donasi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donasi>>> GetListDonasi()
        {
            var donasi = await _donasiService.GetAll();
            return Ok(donasi);
        }

        //Get api/donasi/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Donasi>> GetDonasi(long id)
        {
            var donasi = await _donasiService.GetById(id);

            if (donasi == null)
            {
                return NotFound();
            }

            return Ok(donasi);
        }

        // POST: api/donasi
        [HttpPost]
        public async Task<ActionResult<Donasi>> PostDonasi(Donasi donasi)
        {
            await _donasiService.CreateDonasi(donasi);
            return Ok(donasi);
        }
    }
}

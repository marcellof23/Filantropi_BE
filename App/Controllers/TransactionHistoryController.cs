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
  public class TransactionHistoryController : ControllerBase
  {
    private ITransactionHistoryService _transactionHistoryService;

    public TransactionHistoryController(ITransactionHistoryService transactionHistoryService)
    {
      _transactionHistoryService = transactionHistoryService;
    }

    //Get api/galang_dana
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GalanganDana>>> GetTransactionHistorys()
    {
      var transactionHistory = await _transactionHistoryService.GetAll();
      return Ok(transactionHistory);
    }

    //Get api/galang_dana/id
    [HttpGet("{id}")]
    public async Task<ActionResult<GalanganDana>> GetTransactionHistory(long id)
    {
      var transactionHistory = await _transactionHistoryService.GetById(id);

      if (transactionHistory == null)
      {
        return NotFound();
      }

      return Ok(transactionHistory);
    }
  }
}

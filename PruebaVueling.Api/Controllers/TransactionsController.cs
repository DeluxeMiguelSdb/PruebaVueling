using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaVueling.Core.Interfaces;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaVueling.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IExceptionlogRepository _exceptionlogRepository;
        public TransactionsController(ITransactionService transactionService, IExceptionlogRepository exceptionlogRepository)
        {
            _transactionService = transactionService;
            _exceptionlogRepository = exceptionlogRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                List<TransactionsDto> transactions = await _transactionService.GetTransactions();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _exceptionlogRepository.InsertExceptionLog(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{sku}")]
        public async Task<IActionResult> GetTransaction(string sku)
        {
            try 
            {
                
                TransactionTotalListDto transactions = await _transactionService.GetTransaction(sku);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _exceptionlogRepository.InsertExceptionLog(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}

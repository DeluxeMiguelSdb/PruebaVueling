using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaVueling.Core.Entities;
using PruebaVueling.Core.Interfaces;
using System.Collections.Generic;

namespace PruebaVueling.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionsController(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            //var transactions = new TransactionRepository().GetTransactions();
            //var transactions = _webClient.DownloadString("http://quiet-stone-2094.herokuapp.com/transactions.json");
            IEnumerable<Transactions> transactions = _transactionRepository.GetTransactions();
            return Ok(transactions);
        }

        [HttpGet("{sku}")]
        public IActionResult GetTransaction(string sku)
        {
            //var transactions = new TransactionRepository().GetTransactions();
            //var transactions = _webClient.DownloadString("http://quiet-stone-2094.herokuapp.com/transactions.json");
            Transactions transaction = _transactionRepository.GetTransaction(sku);
            return Ok(transaction);
        }
    }
}

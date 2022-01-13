using Microsoft.AspNetCore.Mvc;
using PruebaVueling.Core.Interfaces;

namespace PruebaVueling.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var transactions = new TransactionRepository().GetTransactions();
            //var transactions = _webClient.DownloadString("http://quiet-stone-2094.herokuapp.com/transactions.json");
            var transactions = _transactionRepository.GetTransactions();
            return Ok(transactions);
        }
    }
}

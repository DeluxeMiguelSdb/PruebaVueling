using PruebaVueling.Core.Entities;
using PruebaVueling.Core.Interfaces;
using PruebaVueling.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVueling.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PruebaVuelingContext _context;
        public TransactionRepository(PruebaVuelingContext context) 
        {
            _context = context;
        }

        public IEnumerable<Transactions> GetTransactions()
        {
            IEnumerable<Transactions> transactions = _context.Transactions.ToList();

            return transactions;
        }
        public Transactions GetTransaction(string sku)
        {
            Transactions transactions = _context.Transactions.FirstOrDefault(x => x.Sku == sku);

            return transactions;
        }

    }
}

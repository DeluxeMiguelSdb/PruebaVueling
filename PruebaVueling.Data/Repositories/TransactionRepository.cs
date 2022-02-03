using PruebaVueling.Core.Interfaces;
using PruebaVueling.Data.Entities;
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

        /// <summary>
        /// Gets transactions from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Transactions>> GetTransactions()
        {
            List<Transactions> transactions = _context.Transactions.ToList();

            return transactions;
        }

        /// <summary>
        /// Gets transactions by SKU from the database
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public List<Transactions> GetTransactionsBySku(string sku)
        {
            List<Transactions> transactions = _context.Transactions.Where(x => x.Sku == sku).ToList();

            return transactions;
        }

        /// <summary>
        /// Persists transactions in database
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public async Task PersistTransactions(List<Transactions> transactions)
        {
            _context.RemoveRange(_context.Transactions.ToList());

            foreach (Transactions transaction in transactions) 
            {
                _context.Transactions.Add(transaction);
            }

            _context.SaveChanges();
        }

    }
}

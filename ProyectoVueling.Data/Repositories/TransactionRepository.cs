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

        public async Task<List<Transactions>> GetTransactions()
        {
            List<Transactions> transactions = _context.Transactions.ToList();

            return transactions;
        }
        public List<Transactions> GetTransactionsBySku(string sku)
        {
            List<Transactions> transactions = _context.Transactions.Where(x => x.Sku == sku).ToList();

            return transactions;
        }

        public void PersistTransactions(List<Transactions> transactions)
        {
            _context.RemoveRange(_context.Transactions.ToList());

            foreach (Transactions transaction in transactions) 
            {
                _context.Transactions.Add(transaction);
            }

            _context.SaveChangesAsync();
        }

    }
}

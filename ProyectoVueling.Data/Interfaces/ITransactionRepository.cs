using PruebaVueling.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaVueling.Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transactions>> GetTransactions();
        List<Transactions> GetTransactionsBySku(string sku);
        void PersistTransactions(List<Transactions> transactions);
    }
}

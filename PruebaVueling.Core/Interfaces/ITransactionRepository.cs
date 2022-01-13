using PruebaVueling.Core.Entities;
using System.Collections.Generic;

namespace PruebaVueling.Core.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transactions> GetTransactions();
    }
}

using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using System.Collections.Generic;

namespace PruebaVueling.Infrastructure.Interfaces
{
    public interface ITransactionMapper
    {
        TransactionTotalListDto ToTransactionDTOMap(List<TransactionsDto> transactions, decimal total);
    }
}
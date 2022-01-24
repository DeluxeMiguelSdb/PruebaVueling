using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using PruebaVueling.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace PruebaVueling.Infrastructure.Mappings
{
    public class TransactionMapper : ITransactionMapper
    {
        public TransactionTotalListDto ToTransactionDTOMap(List<TransactionsDto> transactions, decimal total) 
        {
            return new TransactionTotalListDto()
            {
                Transaction = transactions,
                Total = total
            };
        }
    }
}

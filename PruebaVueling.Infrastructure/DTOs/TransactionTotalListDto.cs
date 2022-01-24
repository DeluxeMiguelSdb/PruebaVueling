using PruebaVueling.Data.Entities;
using System.Collections.Generic;

namespace PruebaVueling.Infrastructure.DTOs
{
    public class TransactionTotalListDto
    {
        public List<TransactionsDto> Transaction { get; set; }
        public decimal? Total { get; set; }
    }
}

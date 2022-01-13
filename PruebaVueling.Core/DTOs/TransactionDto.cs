using PruebaVueling.Core.Entities;
using System.Collections.Generic;

namespace PruebaVueling.Core.DTOs
{
    public class TransactionDto
    {
        public IList<Transactions> Transaction { get; set; }
        public decimal? Total { get; set; }
    }
}

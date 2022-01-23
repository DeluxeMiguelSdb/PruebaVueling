using PruebaVueling.Data.Entities;
using System.Collections.Generic;

namespace PruebaVueling.Infrastructure.DTOs
{
    public class TransactionsDto
    {
        public string Sku { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
    }
}

using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using System.Collections.Generic;

namespace PruebaVueling.Core.Interfaces
{
    public interface ITransactionLogic
    {
        TransactionTotalListDto ConvertCurrency(string sku, List<RatesDto> ratesConversions, string currency, List<Transactions> transactionList = null);
    }
}

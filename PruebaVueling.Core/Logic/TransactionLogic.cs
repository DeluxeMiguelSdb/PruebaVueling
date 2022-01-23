using PruebaVueling.Core.Interfaces;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using PruebaVueling.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaVueling.Core.Logic
{
    public class TransactionLogic : ITransactionLogic
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IRateRepository _rateRepository;
        private readonly ITransactionMapper _transactionMapper;
        private readonly IRateService _rateService;

        public TransactionLogic(ITransactionRepository transactionRepository, IRateRepository rateRepository
                                    ,ITransactionMapper transactionMapper, IRateService rateService) 
        {
            _transactionRepository = transactionRepository;
            _rateRepository = rateRepository;
            _transactionMapper = transactionMapper;
            _rateService = rateService;
        }

        public TransactionTotalListDto ConvertCurrency(string sku, List<RatesDto> ratesConversions, List<Transactions> transactionList = null)
        {
            List<Transactions> filteredList; 

            if (transactionList == null)
            {
                filteredList = _transactionRepository.GetTransactionsBySku(sku);
            }
            else 
            {
                filteredList = transactionList.Where(ef => ef.Sku.Equals(sku)).ToList();
            }

            if (filteredList.Count > 0)
            {
                foreach (Transactions transaction in filteredList) 
                {
                    if (!transaction.Currency.Equals("EUR"))
                    {
                        decimal? rate = ratesConversions.Where(ef => ef.To == "EUR" && ef.From == transaction.Currency)
                                                        .Select(ef => ef.Rate).FirstOrDefault();

                        if (rate != null)
                        {
                            transaction.Amount *= rate;
                        }
                        else
                        {
                            transaction.Amount = CalculateRatesByAnothers(transaction, rate, ratesConversions);
                        }

                        transaction.Currency = "EUR";
                    }
                }

                return _transactionMapper.ToTransactionDTOMap(filteredList, (decimal)filteredList.Sum(ef => ef.Amount));
            }
            else
            {
                throw new Exception(String.Format("Transaction {0} not found",sku));
            }

            
        }

        private decimal? CalculateRatesByAnothers(Transactions transaction, decimal? rate, List<RatesDto> ratesConversions)
        {
            //TODO: RECURRENCIA
            if (rate == null)
            {
                List<RatesDto> baseRates = ratesConversions.Where(ef => ef.From == transaction.Currency).ToList();

                foreach (RatesDto baseRate in baseRates)
                {
                    RatesDto bridgeRate = ratesConversions.Where(ef => ef.From == baseRate.To && ef.To == "EUR").FirstOrDefault();

                    if (bridgeRate != null) 
                    {
                        transaction.Amount = transaction.Amount * baseRate.Rate * bridgeRate.Rate;

                        return transaction.Amount;
                    }
                    return null;
                }

            }

            return null;
        }

        private decimal? CalculateRate(decimal? amount,string from, string to,List<Rates> ratesConversion,decimal? acumulatedRate = 0) 
        {
            //TODO: Terminar este código
            IList<Rates> baseRates = ratesConversion.Where(ef => ef.From == from).ToList();

            foreach (Rates baseRate in baseRates)
            {
                //  Looking for direct conversion
                Rates finalRate = ratesConversion.Where(ef => ef.From == baseRate.To && ef.To == to).FirstOrDefault();

                if (finalRate != null)
                {
                    if (acumulatedRate != 0)
                    {
                        amount *= acumulatedRate * baseRate.Rate;
                    }
                    else
                    {
                        amount *= baseRate.Rate;
                    }

                    return amount;
                }
                //  If its not posible, look for indirect conversions
                else 
                {
                    List<Rates> bridgeRates = ratesConversion.Where(ef => ef.From == baseRate.To).ToList();

                    foreach (Rates bridgeRate in bridgeRates)
                    {
                        if (bridgeRate.To != to && bridgeRate.To != from)
                        {
                            if (acumulatedRate != 0)
                            {
                                acumulatedRate *= baseRate.Rate * bridgeRate.Rate;
                            }
                            else
                            {
                                acumulatedRate = baseRate.Rate * bridgeRate.Rate;
                            }


                            CalculateRate(amount, bridgeRate.To, to, ratesConversion, acumulatedRate);
                        }
                        else if (bridgeRate.To == to)
                        {
                            if (acumulatedRate != 0)
                            {
                                amount *= acumulatedRate * baseRate.Rate;
                            }
                            else
                            {
                                amount *= baseRate.Rate;
                            }

                            return amount;

                        }

                    }
                }

            }

            return null;
        }
    }
}

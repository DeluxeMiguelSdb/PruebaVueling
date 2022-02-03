using AutoMapper;
using PruebaVueling.Core.Interfaces;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using PruebaVueling.Infrastructure.Interfaces;
using PruebaVueling.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaVueling.Core.Logic
{
    public class TransactionLogic : ITransactionLogic
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionMapper _transactionMapper;
        private readonly IMapper _mapper;

        public TransactionLogic(ITransactionRepository transactionRepository, ITransactionMapper transactionMapper, IMapper mapper) 
        {
            _transactionRepository = transactionRepository;
            _transactionMapper = transactionMapper;
            _mapper = mapper;
        }

        /// <summary>
        /// Converts currencies to euros, calculating the exchange rates if necessary
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="ratesConversions"></param>
        /// <param name="currencyTo"></param>
        /// <param name="transactionList"></param>
        /// <returns></returns>
        public TransactionTotalListDto ConvertCurrency(string sku, List<RatesDto> ratesConversions,string currencyTo, List<Transactions> transactionList = null)
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
                    if (!transaction.Currency.Equals(currencyTo))
                    {
                        transaction.Amount = CalculateRate(transaction.Amount, transaction.Currency, currencyTo, ratesConversions);
                    }

                    transaction.Currency = currencyTo;
                }

                List<TransactionsDto> filteredListDto = _mapper.Map<List<TransactionsDto>>(filteredList);

                return _transactionMapper.ToTransactionDTOMap(filteredListDto, (decimal)filteredList.Sum(ef => ef.Amount));
            }
            else
            {
                throw new Exception(String.Format(Resources.ErrorConversionCurrency,sku));
            }

            
        }

        /// <summary>
        /// Searches for currency conversions and calculates non-existing ones
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="ratesConversion"></param>
        /// <param name="notReturnValue"></param>
        /// <returns></returns>
        private decimal? CalculateRate(decimal? amount,string from, string to,List<RatesDto> ratesConversion,string notReturnValue = null) 
        {
            //  Looking for direct conversion
            RatesDto directRate = ratesConversion.Where(ef => ef.From == from && ef.To == to).FirstOrDefault();

            if (directRate != null)
            {
                return amount *= directRate.Rate;
            }
            //  If its not posible, look for indirect conversions
            else
            {
                List<RatesDto> indirectRates = ratesConversion.Where(ef => ef.From == from).ToList();

                foreach (RatesDto indirectRate in indirectRates)
                {
                    RatesDto bridgeRate = ratesConversion.Where(ef => ef.From == indirectRate.To && ef.To == to).FirstOrDefault();

                    if (bridgeRate != null)
                    {
                        return amount *= indirectRate.Rate * bridgeRate.Rate;
                    }
                    else if(indirectRate.To != notReturnValue)
                    {
                        amount *= indirectRate.Rate;
                        decimal? finalAmount = CalculateRate(amount, indirectRate.To, to, ratesConversion, indirectRate.From);

                        if (finalAmount != null)
                        {
                            return finalAmount;
                        }
                    }

                }
            }
            return null;
        }
    }
}

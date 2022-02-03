using AutoMapper;
using Newtonsoft.Json;
using PruebaVueling.Core.Interfaces;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using PruebaVueling.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PruebaVueling.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionLogic _transactionLogic;
        private readonly IMapper _mapper;
        private readonly IRateService _rateService;
        private readonly IExceptionlogRepository _exceptionlogRepository;
        public TransactionService(ITransactionRepository transactionRepository, ITransactionLogic transactionLogic, IMapper mapper,
                                    IRateService rateService, IExceptionlogRepository exceptionlogRepository)
        {
            _transactionRepository = transactionRepository;
            _transactionLogic = transactionLogic;
            _mapper = mapper;
            _rateService = rateService;
            _exceptionlogRepository = exceptionlogRepository;
        }

        /// <summary>
        /// Gets transactions from herokuapp or from database if herokuapp is not available
        /// </summary>
        /// <returns></returns>
        public async Task<List<TransactionsDto>> GetTransactions()
        {
            try {
                string jsonResult;

                using (WebClient client = new WebClient()) 
                {
                    jsonResult = client.DownloadString(Constants.URL_TRANSACTIONS);
                }
                    
                List<Transactions> transactions = JsonConvert.DeserializeObject<List<Transactions>>(jsonResult);

                if (transactions.Count > 0)
                {
                    await _transactionRepository.PersistTransactions(transactions);

                    List<TransactionsDto> transactionsDto = _mapper.Map<List<TransactionsDto>>(transactions);
                    return transactionsDto;
                }
                else
                {
                    //  If client data is not valid, look for data in BBDD
                    transactions = await _transactionRepository.GetTransactions();

                    if (transactions.Count > 0)
                    {
                        List<TransactionsDto>  transactionsDto = _mapper.Map<List<TransactionsDto>>(transactions);
                        return transactionsDto;
                    }

                    throw new Exception(Resources.ErrorFetchingTransactions);
                }
            }
            catch (WebException ex)
            {
                List<Transactions> transactions = await _transactionRepository.GetTransactions();
                List<TransactionsDto> transactionsDto = _mapper.Map<List<TransactionsDto>>(transactions);

                return transactionsDto;
            }

        }

        /// <summary>
        /// Gets the total sum in euro of the transaction entered
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public async Task<TransactionTotalListDto> GetTransaction(string sku)
        {
            try
            {
                string jsonResult;

                using (WebClient client = new WebClient()) 
                {
                    jsonResult = client.DownloadString(Constants.URL_TRANSACTIONS);
                }

                List<Transactions> transactions = JsonConvert.DeserializeObject<List<Transactions>>(jsonResult);

                if (transactions.Count > 0)
                {
                    await _transactionRepository.PersistTransactions(transactions);

                    List<RatesDto> ratesConversions = await _rateService.GetRates();
                    return _transactionLogic.ConvertCurrency(sku, ratesConversions, Constants.EUR_CURRENCY, transactions);
                }
                else
                {
                    //  If client data is not valid, look for data in BBDD
                    transactions = await _transactionRepository.GetTransactions();

                    if (transactions.Count > 0)
                    {
                        List<RatesDto> ratesConversions = await _rateService.GetRates();
                        return _transactionLogic.ConvertCurrency(sku, ratesConversions, Constants.EUR_CURRENCY, transactions);
                    }
                    
                    throw new Exception(Resources.ErrorFetchingTransactions);
                }
            }
            catch (WebException ex)
            {
                List<RatesDto> ratesConversions = await _rateService.GetRates();
                TransactionTotalListDto transactionsTotalList =  _transactionLogic.ConvertCurrency(sku, ratesConversions, Constants.EUR_CURRENCY);

                return transactionsTotalList;
            }
        }
    }
}

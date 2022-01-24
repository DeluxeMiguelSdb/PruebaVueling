using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaVueling.Core.Interfaces;
using PruebaVueling.Core.Logic;
using PruebaVueling.Core.Services;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using PruebaVueling.Infrastructure.Interfaces;
using PruebaVueling.Infrastructure.Mappings;
using System;
using System.Collections.Generic;

namespace PruebaVueling.UnitTests
{
    [TestClass]
    public class TestTransactionLogic
    {
        private static IMapper _mapper;
        public TestTransactionLogic()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
            Mock <ITransactionRepository> transactionRepository= new Mock<ITransactionRepository>();
            TransactionMapper transactionMapper = new TransactionMapper();

            TransactionLogic transactionLogic = new TransactionLogic(transactionRepository.Object, transactionMapper, _mapper);

            #region Creating and filling input data
            string sku = "S2004";
            List<RatesDto> ratesConversions = new List<RatesDto>();

            ratesConversions.Add(new RatesDto()
            {
                From = "USD",
                To = "EUR",
                Rate = (decimal?)1.55

            });
            ratesConversions.Add(new RatesDto()
            {
                From = "EUR",
                To = "USD",
                Rate = (decimal?)1.20

            });
            ratesConversions.Add(new RatesDto()
            {
                From = "USD",
                To = "CAD",
                Rate = (decimal?)0.75

            });
            ratesConversions.Add(new RatesDto()
            {
                From = "CAD",
                To = "USD",
                Rate = (decimal?)0.91

            });
            ratesConversions.Add(new RatesDto()
            {
                From = "EUR",
                To = "AUD",
                Rate = (decimal?)4.33

            });
            ratesConversions.Add(new RatesDto()
            {
                From = "AUD",
                To = "EUR",
                Rate = (decimal?)2.22

            });

            string currencyTo = "AUD";

            List<Transactions> transactionList = new List<Transactions>();

            transactionList.Add(new Transactions()
            {
                Sku = "S2004",
                Amount = (decimal?)25.55,
                Currency = "CAD",
                Id = 0

            });
            transactionList.Add(new Transactions()
            {
                Sku = "S2004",
                Amount = (decimal?)30.80,
                Currency = "AUD",
                Id = 0

            });
            transactionList.Add(new Transactions()
            {
                Sku = "A1440",
                Amount = (decimal?)55.50,
                Currency = "CAD",
                Id = 0

            });

            #endregion Creating and filling input data

            TransactionTotalListDto transactionTotalListDtos = transactionLogic.ConvertCurrency(sku, ratesConversions, currencyTo, transactionList);

            // Total = 30.80 (correct currency) + ( 156.04 -> (25.55 * 0.91 (CAD -> USD) * 1.55 (USD -> EUR) * 4.33 (EUR -> AUD))) = 186,84
            decimal? total = (decimal?)186.84573075;

            Assert.AreEqual(total, transactionTotalListDtos.Total);
        }
    }
}

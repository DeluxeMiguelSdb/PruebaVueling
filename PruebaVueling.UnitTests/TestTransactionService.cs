using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaVueling.Core.Interfaces;
using PruebaVueling.Core.Services;
using PruebaVueling.Infrastructure.DTOs;
using PruebaVueling.Infrastructure.Mappings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaVueling.UnitTests
{
    [TestClass]
    public class TestTransactionService
    {
        private static IMapper _mapper;
        public TestTransactionService()
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
        public async Task TestGetTransactions()
        {
            Mock <ITransactionRepository> transactionRepository= new Mock<ITransactionRepository>();
            Mock<ITransactionLogic> transactionLogic = new Mock<ITransactionLogic>();
            Mock<IRateService> rateService = new Mock<IRateService>();
            Mock<IExceptionlogRepository> exceptionlogRepository = new Mock<IExceptionlogRepository>();
            TransactionMapper transactionMapper = new TransactionMapper();

            TransactionService transactionService = new TransactionService(transactionRepository.Object, transactionLogic.Object, _mapper, rateService.Object, exceptionlogRepository.Object);

            List<TransactionsDto> transactionsDto = await transactionService.GetTransactions();

            Assert.IsNotNull(transactionsDto);
        }
    }
}

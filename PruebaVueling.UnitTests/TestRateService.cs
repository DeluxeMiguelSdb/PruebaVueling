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
    public class TestRateService
    {
        private static IMapper _mapper;
        public TestRateService()
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
            Mock<IRateRepository> rateRepository = new Mock<IRateRepository>(); 

            RateService rateService = new RateService(rateRepository.Object, _mapper);

            List<RatesDto> ratesDto = await rateService.GetRates();

            Assert.IsNotNull(ratesDto);
        }
    }
}

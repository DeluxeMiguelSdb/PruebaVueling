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
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;
        public RateService(IRateRepository rateRepository, IMapper mapper)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
        }

        public async Task<List<RatesDto>> GetRates()
        {
            try
            {
                string jsonResult;

                using (WebClient client = new WebClient())
                {
                    jsonResult = client.DownloadString(Constants.URL_RATES);
                }

                List<Rates> rates = JsonConvert.DeserializeObject<List<Rates>>(jsonResult);

                if (rates.Count > 0)
                {
                    await _rateRepository.PersistRates(rates);

                    List<RatesDto> ratesDto = _mapper.Map<List<RatesDto>>(rates);
                    return ratesDto;
                }
                else 
                {
                    rates = await _rateRepository.GetRates();

                    if (rates.Count > 0)
                    {
                        List<RatesDto> ratesDto = _mapper.Map<List<RatesDto>>(rates);
                        return ratesDto;
                    }

                    throw new Exception(Resources.ErrorFetchingRates);
                }

            }
            catch (WebException ex) 
            {
                List<Rates> rates = await _rateRepository.GetRates();
                List<RatesDto> ratesDto = _mapper.Map<List<RatesDto>>(rates);

                return ratesDto;
            }
        }
    }
}

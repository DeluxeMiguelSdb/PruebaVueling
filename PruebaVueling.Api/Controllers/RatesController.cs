using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaVueling.Core.Interfaces;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaVueling.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRateService _rateService;
        private readonly IExceptionlogRepository _exceptionlogRepository;
        public RatesController(IRateService rateService, IExceptionlogRepository exceptionlogRepository)
        {
            _rateService = rateService;
            _exceptionlogRepository = exceptionlogRepository;
        }

        /// <summary>
        /// Gets rates from herokuapp or from database if herokuapp is not available
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            try
            {
                List<RatesDto> rates = await _rateService.GetRates();
                return Ok(rates);
            }
            catch (Exception ex)
            {
                _exceptionlogRepository.InsertExceptionLog(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
                
        }

    }
}

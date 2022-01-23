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
        public RatesController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            try
            {
                IList<RatesDto> rates = await _rateService.GetRates();
                return Ok(rates);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
                
        }

    }
}

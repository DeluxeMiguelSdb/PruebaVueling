using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaVueling.Core.Interfaces
{
    public interface IRateService
    {
        Task<List<RatesDto>> GetRates();
    }
}
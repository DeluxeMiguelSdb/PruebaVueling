using PruebaVueling.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaVueling.Core.Interfaces
{
    public interface IRateRepository
    {
        Task<List<Rates>> GetRates();
        Task PersistRates(List<Rates> rates);
    }
}

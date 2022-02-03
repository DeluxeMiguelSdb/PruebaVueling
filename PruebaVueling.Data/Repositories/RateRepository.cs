using PruebaVueling.Core.Interfaces;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVueling.Infrastructure.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly PruebaVuelingContext _context;
        public RateRepository(PruebaVuelingContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Gets rates from database
        /// </summary>
        /// <returns></returns>
        public async Task <List<Rates>> GetRates()
        {
            List<Rates> rates = _context.Rates.ToList();

            return rates;
        }

        /// <summary>
        /// Persists rates in database
        /// </summary>
        /// <param name="rates"></param>
        /// <returns></returns>
        public async Task PersistRates (List<Rates> rates)
        {
            _context.RemoveRange(_context.Rates.ToList());

            foreach (Rates rate in rates)
            {
                _context.Rates.Add(rate);
            }

            _context.SaveChanges();
        }
    }
}

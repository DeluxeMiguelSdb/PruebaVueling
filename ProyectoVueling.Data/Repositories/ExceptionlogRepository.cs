using PruebaVueling.Core.Interfaces;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVueling.Infrastructure.Repositories
{
    public class ExceptionlogRepository : IExceptionlogRepository
    {
        private readonly PruebaVuelingContext _context;
        public ExceptionlogRepository(PruebaVuelingContext context) 
        {
            _context = context;
        }

        public void InsertExceptionLog(string description)
        {
            _context.Exceptionslog.Add(new Exceptionslog
            {
                Description = description,
                CreationDate = System.DateTime.Now
            });

            _context.SaveChangesAsync();
        }
    }
}

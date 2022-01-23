using PruebaVueling.Data.Entities;
using System.Collections.Generic;

namespace PruebaVueling.Infrastructure.DTOs
{
    public class RatesDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal? Rate { get; set; }
    }
}

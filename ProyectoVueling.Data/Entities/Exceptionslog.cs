using System;

namespace PruebaVueling.Data.Entities
{
    public partial class Exceptionslog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}

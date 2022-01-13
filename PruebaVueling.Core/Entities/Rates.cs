namespace PruebaVueling.Core.Entities
{
    public partial class Rates
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal? Rate { get; set; }
    }
}

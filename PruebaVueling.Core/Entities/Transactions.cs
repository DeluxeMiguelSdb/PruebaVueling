namespace PruebaVueling.Core.Entities
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal? Aomunt { get; set; }
        public string Currency { get; set; }
    }
}

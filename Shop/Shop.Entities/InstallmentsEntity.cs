namespace Shop.Entities
{
    public class InstallmentsEntity
    {
        public int quantity { get; set; }
        public double amount { get; set; }
        public decimal rate { get; set; }
        public string currency_id { get; set; }
    }
}
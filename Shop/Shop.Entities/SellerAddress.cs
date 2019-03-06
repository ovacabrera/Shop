namespace Shop.Entities
{
    public class SellerAddress
    {
        public string comment { get; set; }
        public string address_line { get; set; }
        public string zip_code { get; set; }
        public City city { get; set; }
        public State state { get; set; }
        public Country country { get; set; }
        public SearchLocation search_location { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public int id { get; set; }
    }
}
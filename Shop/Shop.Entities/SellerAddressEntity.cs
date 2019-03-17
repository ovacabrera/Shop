namespace Shop.Entities
{
    public class SellerAddressEntity
    {
        public string comment { get; set; }
        public string address_line { get; set; }
        public string zip_code { get; set; }
        public CityEntity city { get; set; }
        public StateEntity state { get; set; }
        public CountryEntity country { get; set; }
        public SearchLocationEntity search_location { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public int id { get; set; }
    }
}
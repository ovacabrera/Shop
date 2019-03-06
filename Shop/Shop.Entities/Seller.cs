using System.Collections.Generic;

namespace Shop.Entities
{
    public class Seller
    {
        public int id { get; set; }
        public string power_seller_status { get; set; }
        public bool car_dealer { get; set; }
        public bool real_estate_agency { get; set; }
        public List<object> tags { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Shop.Entities
{
    public class ItemResultEntity
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public SellerEntity seller { get; set; }
        public decimal price { get; set; }
        public string currency_id { get; set; }
        public int available_quantity { get; set; }
        public int sold_quantity { get; set; }
        public string buying_mode { get; set; }
        public string listing_type_id { get; set; }
        public DateTime stop_time { get; set; }
        public string condition { get; set; }
        public string permalink { get; set; }
        public string thumbnail { get; set; }
        public bool accepts_mercadopago { get; set; }
        public InstallmentsEntity installments { get; set; }
        public AddressEntity address { get; set; }
        public ShippingEntity shipping { get; set; }
        //public SellerAddress seller_address { get; set; }
        public List<ItemAttributeEntity> attributes { get; set; }
        public decimal? original_price { get; set; }
        public string category_id { get; set; }
        public object official_store_id { get; set; }
        public object catalog_product_id { get; set; }
        public ReviewsEntity reviews { get; set; }
        public List<string> tags { get; set; }
    }
}
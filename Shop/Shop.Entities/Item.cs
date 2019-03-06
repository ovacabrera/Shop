using System;
using System.Collections.Generic;

namespace Shop.Entities
{
    public class Item
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public object subtitle { get; set; }
        public int seller_id { get; set; }
        public string category_id { get; set; }
        public object official_store_id { get; set; }
        public decimal price { get; set; }
        public decimal base_price { get; set; }
        public object original_price { get; set; }
        public string currency_id { get; set; }
        public int initial_quantity { get; set; }
        public int available_quantity { get; set; }
        public int sold_quantity { get; set; }
        public List<object> sale_terms { get; set; }
        public string buying_mode { get; set; }
        public string listing_type_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime stop_time { get; set; }
        public string condition { get; set; }
        public string permalink { get; set; }
        public string thumbnail { get; set; }
        public string secure_thumbnail { get; set; }
        public List<Picture> pictures { get; set; }
        public object video_id { get; set; }
        public List<Description> descriptions { get; set; }
        public bool accepts_mercadopago { get; set; }
        public List<object> non_mercado_pago_payment_methods { get; set; }
        public Shipping shipping { get; set; }
        public string international_delivery_mode { get; set; }
        public SellerAddress seller_address { get; set; }
        public object seller_contact { get; set; }
        public Location location { get; set; }
        public Geolocation geolocation { get; set; }
        public List<object> coverage_areas { get; set; }
        public List<AttributeX> attributes { get; set; }
        public List<object> warnings { get; set; }
        public string listing_source { get; set; }
        public List<object> variations { get; set; }
        public string status { get; set; }
        public List<object> sub_status { get; set; }
        public List<string> tags { get; set; }
        public object warranty { get; set; }
        public object catalog_product_id { get; set; }
        public string domain_id { get; set; }
        public object parent_item_id { get; set; }
        public object differential_pricing { get; set; }
        public List<object> deal_ids { get; set; }
        public bool automatic_relist { get; set; }
        public DateTime date_created { get; set; }
        public DateTime last_updated { get; set; }
        public double health { get; set; }
    }
}
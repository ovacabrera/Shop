using System;
using System.Collections.Generic;

namespace Shop.DTOs
{
    public class ItemDTO
    {
        public string title { get; set; }
        public decimal price { get; set; }
        public int sold_quantity { get; set; }
        public int available_quantity { get; set; }
        public string itemLargeDescription { get; set; }
        public List<string> picturesUrl { get; set; }
        public List<Tuple<string,string>> attributes { get; set; }        
    }
}

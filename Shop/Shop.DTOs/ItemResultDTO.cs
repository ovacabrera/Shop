using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DTOs
{
    public class ItemResultDTO
    {
        public string id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string thumbnail { get; set; }
        public bool free_shipping { get; set; }
    }
}

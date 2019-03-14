using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DTOs
{
    public class ItemResultDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public bool FreeShipping { get; set; }
    }
}

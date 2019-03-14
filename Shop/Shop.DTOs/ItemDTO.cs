using System;
using System.Collections.Generic;

namespace Shop.DTOs
{
    public class ItemDTO
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int SoldQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public string ItemLargeDescription { get; set; }
        public List<string> PicturesUrl { get; set; }
        public List<Tuple<string,string>> Attributes { get; set; }        
    }
}

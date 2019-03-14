using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DTOs
{
    public class SearchResultDTO
    {
        public int totalItemCount;        
        public List<ItemResultDTO> results { get; set; }
    }
}

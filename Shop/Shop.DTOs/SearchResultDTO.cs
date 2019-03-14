using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DTOs
{
    public class SearchResultDTO
    {
        public int TotalItemCount { get; set; }
        public List<ItemResultDTO> Results { get; set; }
    }
}

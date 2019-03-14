using System.Collections.Generic;

namespace Shop.Entities
{
    public class SearchResultEntity
    {
        public string site_id { get; set; }
        public string query { get; set; }
        public PagingEntity paging { get; set; }
        public List<ItemResultEntity> results { get; set; }
        public List<object> secondary_results { get; set; }
        public List<object> related_results { get; set; }
        public SortEntity sort { get; set; }
        public List<SortEntity> available_sorts { get; set; }
        public List<FilterEntity> filters { get; set; }
        public List<AvailableFilterEntity> available_filters { get; set; }
    }
}
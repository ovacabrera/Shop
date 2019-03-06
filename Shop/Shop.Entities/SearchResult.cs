using System.Collections.Generic;

namespace Shop.Entities
{
    public class SearchResult
    {
        public string site_id { get; set; }
        public string query { get; set; }
        public Paging paging { get; set; }
        public List<Result> results { get; set; }
        public List<object> secondary_results { get; set; }
        public List<object> related_results { get; set; }
        public Sort sort { get; set; }
        public List<Sort> available_sorts { get; set; }
        public List<Filter> filters { get; set; }
        public List<AvailableFilter> available_filters { get; set; }
    }
}
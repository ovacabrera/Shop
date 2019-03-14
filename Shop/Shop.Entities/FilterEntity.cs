using System.Collections.Generic;

namespace Shop.Entities
{
    public class FilterEntity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<FilterValueEntity> values { get; set; }
    }
}
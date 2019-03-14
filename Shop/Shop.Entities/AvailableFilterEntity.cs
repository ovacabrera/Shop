using System.Collections.Generic;

namespace Shop.Entities
{
    public class AvailableFilterEntity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<AvailableFilterValueEntity> values { get; set; }
    }
}
using System.Collections.Generic;

namespace Shop.Entities
{
    public class AvailableFilter
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<Value2> values { get; set; }
    }
}
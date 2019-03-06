using System.Collections.Generic;

namespace Shop.Entities
{
    public class Value
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<PathFromRoot> path_from_root { get; set; }
    }
}
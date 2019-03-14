using System.Collections.Generic;

namespace Shop.Entities
{
    public class FilterValueEntity
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<FilterPathFromRootEntity> path_from_root { get; set; }
    }
}
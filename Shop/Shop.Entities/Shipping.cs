using System.Collections.Generic;

namespace Shop.Entities
{
    public class Shipping
    {
        public string mode { get; set; }
        public List<object> methods { get; set; }
        public List<string> tags { get; set; }
        public object dimensions { get; set; }
        public bool local_pick_up { get; set; }
        public bool free_shipping { get; set; }
        public string logistic_type { get; set; }
        public bool store_pick_up { get; set; }
    }
}
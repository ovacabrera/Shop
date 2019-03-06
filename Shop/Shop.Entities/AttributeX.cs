namespace Shop.Entities
{
    public class AttributeX
    {
        public string id { get; set; }
        public string name { get; set; }
        public string value_id { get; set; }
        public string value_name { get; set; }
        public ValueStruct value_struct { get; set; }
        public string attribute_group_id { get; set; }
        public string attribute_group_name { get; set; }
    }
}
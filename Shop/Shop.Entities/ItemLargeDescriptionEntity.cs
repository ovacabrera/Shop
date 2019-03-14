using System;

namespace Shop.Entities
{
    public class ItemLargeDescriptionEntity
    {
        public string text { get; set; }
        public string plain_text { get; set; }
        public DateTime last_updated { get; set; }
        public DateTime date_created { get; set; }
        public SnapshotEntity snapshot { get; set; }
    }
}
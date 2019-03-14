namespace Shop.Entities
{
    public class SearchLocationEntity
    {
        public NeighborhoodEntity neighborhood { get; set; }
        public CityEntity city { get; set; }
        public StateEntity state { get; set; }
    }
}
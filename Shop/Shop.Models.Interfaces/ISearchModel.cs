using Shop.Entities;

namespace Shop.Models.Interfaces
{
    public interface ISearchModel
    {
        SearchResult SearchItems(string filter, int? offset, int? limit);
    }
}

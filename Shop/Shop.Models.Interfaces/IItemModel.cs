using Shop.Entities;

namespace Shop.Models.Interfaces
{
    public interface IItemModel
    {
        Item GetItem(string id);

        LargeDescription GetLargeDescription(string itemId);

        SearchResult SearchItems(string filter, int? offset, int? limit);

    }
}

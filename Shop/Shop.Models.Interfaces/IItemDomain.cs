using Shop.Entities;

namespace Shop.Models.Interfaces
{
    public interface IItemDomain
    {
        ItemEntity GetItem(string id);

        //ItemLargeDescriptionEntity GetLargeDescription(string itemId);

        SearchResultEntity SearchItems(string filter, int? offset, int? limit);

    }
}

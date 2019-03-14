using Shop.Entities;

namespace Shop.ExternalServices.Interfaces
{
    public interface IExternalService
    {
        ItemEntity GetItem(string id);

        ItemLargeDescriptionEntity GetItemLargeDescription(string itemId);

        SearchResultEntity SearchItems(string filter, int? offset, int? limit);
    }
}

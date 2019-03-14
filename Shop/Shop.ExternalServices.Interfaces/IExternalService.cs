using Shop.Entities;

namespace Shop.ExternalServices.Interfaces
{
    public interface IExternalService
    {
        ItemEntity GetItem(string id, ref string responseMessage);

        ItemLargeDescriptionEntity GetItemLargeDescription(string itemId, ref string responseMessage);

        SearchResultEntity SearchItems(string filter, int? offset, int? limit, ref string responseMessage);
    }
}

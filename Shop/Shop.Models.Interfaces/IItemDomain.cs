using Shop.Entities;

namespace Shop.Models.Interfaces
{
    public interface IItemDomain
    {
        ItemEntity GetItem(string id, ref string responseMessage);

        SearchResultEntity SearchItems(string filter, int? offset, int? limit, ref string responseMessage);

    }
}

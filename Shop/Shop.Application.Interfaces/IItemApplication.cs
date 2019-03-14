using Shop.DTOs;

namespace Shop.Application.Interfaces
{
    public interface IItemApplication
    {
        ItemDTO GetItem(string itemId, ref string responseMessage);
        SearchResultDTO SearchItems(string filter, int? offset, int? limit, ref string responseMessage);
    }
}
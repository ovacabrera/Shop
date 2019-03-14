using Shop.DTOs;

namespace Shop.Application.Interfaces
{
    public interface IItemApplication
    {
        ItemDTO GetItem(string itemId);
        SearchResultDTO SearchItems(string filter, int? offset, int? limit);
    }
}
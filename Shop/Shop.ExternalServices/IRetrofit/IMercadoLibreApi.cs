using System.Threading.Tasks;
using Refit;
using Shop.Entities;

namespace Shop.ExternalServices.IRetrofit
{
    public interface IMercadoLibreApi
    {
        [Get("/items/{Item_id}")]
        Task<ItemEntity> GetItem(string Item_id);

        [Get("/items/{Item_id}/description")]
        Task<ItemLargeDescriptionEntity> GetItemLargeDescription(string Item_id);

        [Get("/sites/MLA/search")]
        Task<SearchResultEntity> SearchItems(
            [AliasAs("q")]string filter,
            int? offset,
            int? limit
        );
    }
}

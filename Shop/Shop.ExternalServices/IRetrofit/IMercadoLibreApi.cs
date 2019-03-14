using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using Shop.Entities;

namespace Shop.ExternalServices.IRetrofit
{
    public interface IMercadoLibreApi
    {
        [Get("/items/{Item_id}")]
        Task<HttpResponseMessage> GetItem(string Item_id);

        [Get("/items/{Item_id}/description")]
        Task<HttpResponseMessage> GetItemLargeDescription(string Item_id);

        [Get("/sites/MLA/search")]
        Task<HttpResponseMessage> SearchItems(
            [AliasAs("q")]string filter,
            int? offset,
            int? limit
        );
    }
}

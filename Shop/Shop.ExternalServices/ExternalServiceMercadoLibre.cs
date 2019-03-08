using System;
using Refit;
using Shop.Entities;
using Shop.ExternalServices.IRetrofit;

namespace Shop.ExternalServices
{
    public class ExternalServiceMercadoLibre : IExternalService
    {
        public Item GetItem(string id)
        {
            try
            {
                var mercadoLibreApi = RestService.For<IMercadoLibreApi>("https://api.mercadolibre.com");

                return mercadoLibreApi.GetItem(id).Result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public LargeDescription GetItemLargeDescription(string id)
        {
            try
            {
                var mercadoLibreApi = RestService.For<IMercadoLibreApi>("https://api.mercadolibre.com");
                return mercadoLibreApi.GetItemLargeDescription(id).Result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public SearchResult SearchItems(string filter, int? offset, int? limit)
        {
            try
            {
                var mercadoLibreApi = RestService.For<IMercadoLibreApi>("https://api.mercadolibre.com");
                return mercadoLibreApi.SearchItems(filter,offset,limit).Result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

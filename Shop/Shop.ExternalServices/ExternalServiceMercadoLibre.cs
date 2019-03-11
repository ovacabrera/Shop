using System;
using System.Configuration;
using Refit;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.ExternalServices.IRetrofit;

namespace Shop.ExternalServices
{
    public class ExternalServiceMercadoLibre : IExternalService
    {
        private string _url;

        public ExternalServiceMercadoLibre()
        {
            _url = ConfigurationManager.AppSettings["APIMercadoLibre"];
        }

        public Item GetItem(string id)
        {
            var mercadoLibreApi = RestService.For<IMercadoLibreApi>(_url);
            return mercadoLibreApi.GetItem(id).Result;
        }

        public LargeDescription GetItemLargeDescription(string id)
        {
            var mercadoLibreApi = RestService.For<IMercadoLibreApi>(_url);
            return mercadoLibreApi.GetItemLargeDescription(id).Result;
        }

        public SearchResult SearchItems(string filter, int? offset, int? limit)
        {
            var mercadoLibreApi = RestService.For<IMercadoLibreApi>(_url);
            return mercadoLibreApi.SearchItems(filter,offset,limit).Result;
        }
    }
}

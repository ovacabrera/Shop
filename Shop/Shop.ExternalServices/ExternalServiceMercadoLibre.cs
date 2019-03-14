using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Refit;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.ExternalServices.IRetrofit;

namespace Shop.ExternalServices
{
    public class ExternalServiceMercadoLibre : IExternalService
    {
        private string _url;

        public ExternalServiceMercadoLibre(string url)
        {
            _url = url;
        }

        public ItemEntity GetItem(string id, ref string responseMessage)
        {
            var mercadoLibreApi = RestService.For<IMercadoLibreApi>(_url);
            HttpResponseMessage response = mercadoLibreApi.GetItem(id).Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ItemEntity>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                ResponseMessageManager(out responseMessage, response);
                return null;
            }
        }

        public ItemLargeDescriptionEntity GetItemLargeDescription(string id, ref string responseMessage)
        {
            var mercadoLibreApi = RestService.For<IMercadoLibreApi>(_url);
            HttpResponseMessage response = mercadoLibreApi.GetItemLargeDescription(id).Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ItemLargeDescriptionEntity>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                ResponseMessageManager(out responseMessage, response);
                return null;
            }               
        }

        public SearchResultEntity SearchItems(string filter, int? offset, int? limit, ref string responseMessage)
        {
            var mercadoLibreApi = RestService.For<IMercadoLibreApi>(_url);
            HttpResponseMessage response = mercadoLibreApi.SearchItems(filter, offset, limit).Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SearchResultEntity>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                ResponseMessageManager(out responseMessage, response);
                return null;
            }
        }

        private static void ResponseMessageManager(out string responseMessage, HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    responseMessage = "No tenés autorización para ver la página.";
                    break;
                case HttpStatusCode.NotFound:
                    responseMessage = "Parece que la página no existe.";
                    break;
                case HttpStatusCode.RequestTimeout:
                    responseMessage = "La consulta no puede ser realizada. Intente de nuevo en unos minutos.";
                    break;
                case HttpStatusCode.InternalServerError:
                    responseMessage = "Error interno del servidor. Código: " + response.StatusCode;
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    responseMessage = "Servicio no disponible. Código: " + response.StatusCode;
                    break;
                default:
                    responseMessage = "Error Inesperado. Código: " + response.StatusCode;
                    break;
            }
        }
    }
}

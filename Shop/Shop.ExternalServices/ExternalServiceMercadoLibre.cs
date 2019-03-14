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
        private IMercadoLibreApi _mercadoLibreApi;

        public ExternalServiceMercadoLibre(string url)
        {
            _url = url;
            _mercadoLibreApi = RestService.For<IMercadoLibreApi>(_url);
        }

        public ItemEntity GetItem(string id, ref string responseMessage)
        {
            HttpResponseMessage response = _mercadoLibreApi.GetItem(id).Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ItemEntity>(response.Content.ReadAsStringAsync().Result);
            }

            ResponseMessageManager(out responseMessage, response.StatusCode);
            return null;
        }

        public ItemLargeDescriptionEntity GetItemLargeDescription(string id, ref string responseMessage)
        {
            HttpResponseMessage response = _mercadoLibreApi.GetItemLargeDescription(id).Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ItemLargeDescriptionEntity>(response.Content.ReadAsStringAsync().Result);
            }

            ResponseMessageManager(out responseMessage, response.StatusCode);
            return null;
        }

        public SearchResultEntity SearchItems(string filter, int? offset, int? limit, ref string responseMessage)
        {
            HttpResponseMessage response = _mercadoLibreApi.SearchItems(filter, offset, limit).Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SearchResultEntity>(response.Content.ReadAsStringAsync().Result);
            }

            ResponseMessageManager(out responseMessage, response.StatusCode);
            return null;
        }

        private static void ResponseMessageManager(out string responseMessage, HttpStatusCode statusCode)
        {
            switch (statusCode)
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
                    responseMessage = "Error interno del servidor. Código: " + statusCode;
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    responseMessage = "Servicio no disponible. Código: " + statusCode;
                    break;
                default:
                    responseMessage = "Error Inesperado. Código: " + statusCode;
                    break;
            }
        }
    }
}

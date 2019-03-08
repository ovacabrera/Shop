using Shop.Entities;
using Shop.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class SearchModel : ISearchModel
    {
        public SearchResult SearchItems(string filter, int? offset, int? limit)
        {
            IExternalService consultaExternalService = new ExternalServiceMercadoLibre();
            return consultaExternalService.SearchItems(filter, offset, limit);
        }
    }
}

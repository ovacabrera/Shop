using Shop.CrossCutting;
using Shop.Entities;
using Shop.ExternalServices;
using Shop.ExternalServices.Interfaces;
using Shop.Models.Interfaces;
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
            IExternalService consultaExternalService = IoC.GetObjectExternalService<IExternalService>();
            return consultaExternalService.SearchItems(filter, offset, limit);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Entities;
using Shop.ExternalServices;

namespace Shop.Models
{
    public class ItemModel : IItemModel
    {
        public Item GetItem(string id)
        {
            IExternalService consultaExternalService = new ExternalServiceMercadoLibre();
            return consultaExternalService.GetItem(id);
        }

        public LargeDescription GetLargeDescription(string itemId)
        {
            IExternalService consultaExternalService = new ExternalServiceMercadoLibre();
            return consultaExternalService.GetItemLargeDescription(itemId);
        }

        public SearchResult GetItems(string q)
        {
            IExternalService consultaExternalService = new ExternalServiceMercadoLibre();
            return consultaExternalService.GetItems(q);
        }
    }
}

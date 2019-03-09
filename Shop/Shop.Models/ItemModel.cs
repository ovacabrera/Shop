using Shop.CrossCutting;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.Models.Interfaces;

namespace Shop.Models
{
    public class ItemModel : IItemModel
    {
        public Item GetItem(string id)
        {
            IExternalService consultaExternalService = IoC.GetObjectExternalService<IExternalService>();
            return consultaExternalService.GetItem(id);
        }

        public LargeDescription GetLargeDescription(string itemId)
        {
            IExternalService consultaExternalService = IoC.GetObjectExternalService<IExternalService>();
            return consultaExternalService.GetItemLargeDescription(itemId);
        }
    }
}

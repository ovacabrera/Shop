using Shop.CrossCutting;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.Models.Interfaces;

namespace Shop.Models
{
    public class ItemModel : IItemModel
    {
        public Item GetItem(string itemId)
        {
            if (!ValidateItemIdParameter(itemId)) return null;

            var externalService = IoC.GetObjectExternalService<IExternalService>();
            return externalService.GetItem(itemId);
        }

        public LargeDescription GetLargeDescription(string itemId)
        {
            if (!ValidateItemIdParameter(itemId)) return null;

            var externalService = IoC.GetObjectExternalService<IExternalService>();
            return externalService.GetItemLargeDescription(itemId);
        }

        public bool ValidateItemIdParameter(string itemId)
        {
            return itemId.Trim() != string.Empty;
        }
    }
}

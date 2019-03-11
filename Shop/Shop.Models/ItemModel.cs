using Shop.CrossCutting;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.Models.Interfaces;

namespace Shop.Models
{
    public class ItemModel : IItemModel
    {
        private IExternalService _externalService;

        public ItemModel(IExternalService externalService)
        {
            _externalService = externalService;
        }

        public Item GetItem(string itemId)
        {
            if (!ValidateItemIdParameter(itemId)) return null;

            return _externalService.GetItem(itemId);
        }

        public LargeDescription GetLargeDescription(string itemId)
        {
            if (!ValidateItemIdParameter(itemId)) return null;

            return _externalService.GetItemLargeDescription(itemId);
        }

        public bool ValidateItemIdParameter(string itemId)
        {
            return itemId.Trim() != string.Empty;
        }
    }
}

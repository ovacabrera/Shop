using Shop.CrossCutting;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.Models.Interfaces;

namespace Shop.Models
{
    public class ItemDomain : IItemDomain
    {
        private IExternalService _externalService;
        private ILoggerService _logger;

        public ItemDomain(IExternalService externalService, ILoggerService logger)
        {
            _externalService = externalService;
            _logger = logger;
        }

        public ItemEntity GetItem(string itemId)
        {
            try
            {
                if (!ValidateItemIdParameter(itemId)) return null;

                var item = _externalService.GetItem(itemId);
                if (item != null)
                {
                    item.ItemLargeDescription = _externalService.GetItemLargeDescription(itemId);
                }

                return item;

            }
            catch (System.Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        //public ItemLargeDescriptionEntity GetLargeDescription(string itemId)
        //{
        //    try
        //    {
        //        if (!ValidateItemIdParameter(itemId)) return null;

        //        return _externalService.GetItemLargeDescription(itemId);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        _logger.Error(ex);
        //        return null;
        //    }
        //}

        public bool ValidateItemIdParameter(string itemId)
        {
            return itemId.Trim() != string.Empty;
        }

        public SearchResultEntity SearchItems(string filter, int? offset, int? limit)
        {
            try
            {
                if (!ValidateSearchItemsParameters(filter, offset, limit)) return null;

                return _externalService.SearchItems(filter, offset, limit);
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        public bool ValidateSearchItemsParameters(string filter, int? offset, int? limit)
        {
            if (filter.Trim() == string.Empty)
            {
                return false;
            }

            if (offset.HasValue && offset < 0)
            {
                return false;
            }

            if (limit.HasValue && limit < 0)
            {
                return false;
            }

            return true;
        }
    }
}

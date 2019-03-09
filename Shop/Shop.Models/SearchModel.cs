using Shop.CrossCutting;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.Models.Interfaces;

namespace Shop.Models
{
    public class SearchModel : ISearchModel
    {
        public SearchResult SearchItems(string filter, int? offset, int? limit)
        {
            if (!ValidateSearchItemsParameters(filter, offset, limit)) return null;

            var consultaExternalService = IoC.GetObjectExternalService<IExternalService>();
            return consultaExternalService.SearchItems(filter, offset, limit);
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

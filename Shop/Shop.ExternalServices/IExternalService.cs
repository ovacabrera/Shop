using System.Collections.Generic;
using Shop.Entities;

namespace Shop.ExternalServices
{
    public interface IExternalService
    {
        Item GetItem(string id);

        LargeDescription GetItemLargeDescription(string itemId);

        SearchResult SearchItems(string filter, int? offset, int? limit);
    }
}

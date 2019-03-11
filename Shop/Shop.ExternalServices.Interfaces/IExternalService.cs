﻿using Shop.Entities;

namespace Shop.ExternalServices.Interfaces
{
    public interface IExternalService
    {
        Item GetItem(string id);

        LargeDescription GetItemLargeDescription(string itemId);

        SearchResult SearchItems(string filter, int? offset, int? limit);
    }
}

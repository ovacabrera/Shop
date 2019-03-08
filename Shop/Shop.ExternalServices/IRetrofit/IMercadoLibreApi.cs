﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Shop.Entities;

namespace Shop.ExternalServices.IRetrofit
{
    public interface IMercadoLibreApi
    {
        [Get("/items/{Item_id}")]
        Task<Item> GetItem(string Item_id);

        //[Get("/sites/MLA/search?q={q}")]
        //Task<SearchResult> GetItems(
        //    [AliasAs("q")]string filter
        //    );

        [Get("/items/{Item_id}/description")]
        Task<LargeDescription> GetItemLargeDescription(string Item_id);

        [Get("/sites/MLA/search")]
        Task<SearchResult> SearchItems(
            [AliasAs("q")]string filter,
            int? offset,
            int? limit
        );
    }
}

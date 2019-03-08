using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Entities;

namespace Shop.Models
{
    public interface ISearchModel
    {
        SearchResult SearchItems(string filter, int? offset, int? limit);
    }
}

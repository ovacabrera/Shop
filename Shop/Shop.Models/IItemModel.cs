using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Entities;

namespace Shop.Models
{
    public interface IItemModel
    {
        Item GetItem(string id);

        LargeDescription GetLargeDescription(string itemId);

        SearchResult GetItems(string q);
    }
}

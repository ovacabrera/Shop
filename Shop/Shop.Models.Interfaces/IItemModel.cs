using Shop.Entities;

namespace Shop.Models.Interfaces
{
    public interface IItemModel
    {
        Item GetItem(string id);

        LargeDescription GetLargeDescription(string itemId);

    }
}

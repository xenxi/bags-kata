using System.Collections.Generic;

namespace BagKata
{
    public interface IInventory
    {
        void Add(Item item);
        IList<IBag> GetBags();
        bool IsEmpty();
    }
}
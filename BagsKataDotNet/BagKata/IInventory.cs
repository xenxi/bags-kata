using System.Collections.Generic;

namespace BagKata
{
    public interface IInventory
    {
        void Add(string leather);
        IEnumerable<string> GetItems();
        IList<IBag> GetBags();
    }
}
using System.Collections.Generic;

namespace BagKata
{
    public interface IInventory
    {
        void Add(string leather);
        IList<IBag> GetBags();
    }
}
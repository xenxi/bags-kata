using System.Collections.Generic;

namespace BagKata
{
    public interface IBag
    {
        void Add(string aGivenAnyItem);
        bool IsFull();
        IEnumerable<string> GetItems();
    }
}
using System.Collections.Generic;

namespace BagKata
{
    public interface IBag
    {
        void Add(Item item);
        bool IsFull();
        IEnumerable<Item> GetItems();
        Category Category { get; }
        bool IsEmpty();
    }
}
using System.Collections.Generic;

namespace BagKata
{
    public interface IBag
    {
        void Add(string item);
        bool IsFull();
        IEnumerable<string> GetItems();
        Category Category { get; }
        bool IsEmpty();
    }
}
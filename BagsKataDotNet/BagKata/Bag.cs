using System;
using System.Collections.Generic;

namespace BagKata
{
    public class Bag : IBag
    {
        private readonly List<string> _items = new List<string>();

        public void Add(string item)
        {
            EnsureHasFreeSlots();

            _items.Add(item);
        }

        private void EnsureHasFreeSlots()
        {
            if (IsFull())
                throw new InvalidOperationException("the bag is complete");
        }

        public int FreeSlots() => 4 - _items.Count;
        public IEnumerable<string> GetItems() => _items.AsReadOnly();

        public bool IsFull() => FreeSlots() < 1;
    }
}
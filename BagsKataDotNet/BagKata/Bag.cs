using System;
using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class Bag : IBag
    {
        private readonly int _capacity;
        private readonly List<string> _items = new List<string>();

        public Bag(Category bagCategory, int capacity  = 4)
        {
            Category = bagCategory;
            _capacity = capacity;
        }

        public Category Category { get; }

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

        public int FreeSlots() => _capacity - _items.Count;
        public IEnumerable<string> GetItems() => _items.AsReadOnly();

        public bool IsFull() => FreeSlots() < 1;

        public bool IsEmpty() => !_items.Any();
    }
}
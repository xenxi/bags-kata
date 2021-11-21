using System;
using System.Collections.Generic;
using System.Text;

namespace BagKata
{
    public class Bag : IBag
    {
        private List<string> _items = new List<string>();

        public int FreeSlots() => 4;

        public void Add(string item) => _items.Add(item);

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetItems() => _items.AsReadOnly();
    }
}

﻿using System;
using System.Collections.Generic;

namespace BagKata
{
    public class Bag : IBag
    {
        private List<string> _items = new List<string>();

        public void Add(string item)
        {
            if (IsFull())
                throw new InvalidOperationException("the bag is complete");

            _items.Add(item);
        }

        public int FreeSlots() => 4 - _items.Count;
        public IEnumerable<string> GetItems() => _items.AsReadOnly();

        public bool IsFull() => FreeSlots() < 1;
    }
}
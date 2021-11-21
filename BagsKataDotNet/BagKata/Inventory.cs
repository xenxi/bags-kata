﻿using System.Collections.Generic;

namespace BagKata
{
    public class Inventory
    {
        public readonly IBackpack _backpack;
        public readonly List<string> _items;
        public IBag _bag;
        public readonly IBag _secondBag;

        public Inventory(IBackpack backpack, IBag bag, IBag secondBag)
        {
            _backpack = backpack;
            _bag = bag;
            _secondBag = secondBag;
            _items = new List<string>();
        }
    }
}
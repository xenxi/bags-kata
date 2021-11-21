using System.Collections.Generic;

namespace BagKata
{
    public class Inventory : IInventory
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

        public void Add(string leather)
        {
            if (!_backpack.IsFull())
                _backpack.Add(leather);
            else if (!_bag.IsFull())
                _bag.Add(leather);
            else
                _secondBag.Add(leather);

            _items.Add(leather);
        }
    }
}
using System.Collections.Generic;

namespace BagKata
{
    public class Inventory : IInventory
    {
        private readonly IBackpack _backpack;
        private readonly List<string> _items;
        private readonly IBag _bag;
        private readonly IBag _secondBag;

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

        public IEnumerable<string> GetItems() => _items;
    }
}
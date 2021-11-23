using System;
using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class Inventory : IInventory
    {
        private readonly IList<IBag> _bags;

        public Inventory(IList<IBag> bags)
        {
            _bags = bags;
        }

        public void Add(string leather)
        {
            var bagWithSpace = _bags.FirstOrDefault(bag => !bag.IsFull()) ?? throw new InvalidOperationException("no free space in inventory");
            bagWithSpace.Add(leather);
        }

        public IList<IBag> GetBags() => _bags;
    }
}
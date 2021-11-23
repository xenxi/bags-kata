using System;
using System.Collections.Generic;

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
            foreach (var bag in _bags)
            {
                if (!bag.IsFull())
                {
                    bag.Add(leather);
                    return;
                }
            }
            throw new InvalidOperationException("no free space in inventory");
        }

        public IList<IBag> GetBags() => _bags;
    }
}
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

        public void Add(string leather) => FirstBagWithSpace().Add(leather);

        private IBag FirstBagWithSpace() =>
            _bags.FirstOrDefault(bag => !bag.IsFull()) ??
            throw new InvalidOperationException("no free space in inventory");

        public IList<IBag> GetBags() => _bags;
        public bool IsEmpty() => _bags.All(x => x.IsEmpty());
    }
}
using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class Inventory : IInventory
    {


        private IList<IBag> _bags;


        public Inventory(IList<IBag> bags)
        {
            _bags = bags;
        }

        public void Add(string leather)
        {
            foreach (var bag in _bags)
            {
                if(!bag.IsFull())
                {
                    bag.Add(leather);
                    return;
                }
            }
        }

        public IEnumerable<IBag> GetBags() => _bags;

        public IEnumerable<string> GetItems() => _bags.SelectMany(x => x.GetItems());
    }
}
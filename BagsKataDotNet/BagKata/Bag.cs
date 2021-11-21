using System;
using System.Collections.Generic;
using System.Text;

namespace BagKata
{
    public class Bag : IBag
    {
        public void Add(string aGivenAnyItem)
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}

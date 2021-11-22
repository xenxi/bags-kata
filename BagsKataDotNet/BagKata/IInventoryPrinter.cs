using System.Collections.Generic;

namespace BagKata
{
    public interface IInventoryPrinter
    {
        void Print(IEnumerable<IBag> bags);
    }
}
using System.Collections.Generic;

namespace BagKata
{
    public interface IInventoryPrinter
    {
        void Print(IList<IBag> bags);
    }
}
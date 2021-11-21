using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class InventoryPrinter : IInventoryPrinter
    {
        private readonly IPrinter _printer;

        public InventoryPrinter(IPrinter printer)
        {
            _printer = printer;
        }

        public void Print(IInventory inventory)
        {
            IEnumerable<string> items = inventory.GetItems();

            _printer.Print($"backpack = [{string.Join(", ", items.Select(x => $"'{x}'"))}]");

            _printer.Print("bag_with_metals_category = []");
            _printer.Print("bag_with_no_category = []");
            _printer.Print("bag_with_weapons_category = []");
            _printer.Print("bag_with_no_category = []");
        }
    }
}
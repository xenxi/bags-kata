using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class StringPrinter
    {
        private readonly IPrinter _printer;

        public StringPrinter(IPrinter printer)
        {
            _printer = printer;
        }

        public void printInventory(IInventory inventory)
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
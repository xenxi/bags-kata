using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class Character
    {
        private readonly IInventory _inventory;
        private readonly IPrinter _printer;

        public Character(IPrinter printer, IInventory inventory)
        {
            _printer = printer;
            _inventory = inventory;
        }

        public void Add(string leather) => _inventory.Add(leather);

        public void PrintInventory()
        {
            printInventory(_printer, _inventory);
        }

        private static void printInventory(IPrinter printer, IInventory inventory)
        {
            IEnumerable<string> items = inventory.GetItems();
            printer.Print($"backpack = [{string.Join(", ", items.Select(x => $"'{x}'"))}]");

            printer.Print("bag_with_metals_category = []");
            printer.Print("bag_with_no_category = []");
            printer.Print("bag_with_weapons_category = []");
            printer.Print("bag_with_no_category = []");
        }
    }
}
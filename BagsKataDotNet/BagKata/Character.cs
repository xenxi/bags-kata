using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class Character
    {
        private readonly Inventory _inventory;
        private readonly IPrinter _printer;
        public Character(IPrinter printer, Inventory inventory)
        {
            _printer = printer;
            _inventory = inventory;
        }

        public void Add(string leather)
        {
            if (!_inventory._backpack.IsFull())
                _inventory._backpack.Add(leather);
            else if (!_inventory._bag.IsFull())
                _inventory._bag.Add(leather);
            else
                _inventory._secondBag.Add(leather);

            _inventory._items.Add(leather);
        }

        public void PrintInventory()
        {
            PrintBackpack();

            _printer.Print("bag_with_metals_category = []");
            _printer.Print("bag_with_no_category = []");
            _printer.Print("bag_with_weapons_category = []");
            _printer.Print("bag_with_no_category = []");
        }

        private static string PrintItems(IEnumerable<string> items) => string.Join(", ", items.Select(x => $"'{x}'"));

        private void PrintBackpack() => _printer.Print($"backpack = [{PrintItems(_inventory._items)}]");
    }
}
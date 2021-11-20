using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class Character
    {
        private readonly IPrinter _printer;
        private readonly List<string> _items;
        public Character(IPrinter printer)
        {
            _printer = printer;
            _items = new List<string>();
        }

        public void Add(string leather)
        {
            _items.Add(leather);
        }

        public void PrintInventory()
        {
            PrintBackpack();

            _printer.Print("bag_with_metals_category = []");
            _printer.Print("bag_with_no_category = []");
            _printer.Print("bag_with_weapons_category = []");
            _printer.Print("bag_with_no_category = []");
        }

        private void PrintBackpack() => _printer.Print($"backpack = [{PrintItems(_items)}]");

        private static string PrintItems(IEnumerable<string> items) => string.Join(", ", items.Select(x => $"'{x}'"));
    }
}
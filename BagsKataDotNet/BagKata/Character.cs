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
            if(_items.Any())
                _printer.Print($"backpack = [{string.Join(", ", _items.Select(x => $"'{x}'"))}]");
            else
                _printer.Print("backpack = []");

            _printer.Print("bag_with_metals_category = []");
            _printer.Print("bag_with_no_category = []");
            _printer.Print("bag_with_weapons_category = []");
            _printer.Print("bag_with_no_category = []");
        }
    }
}
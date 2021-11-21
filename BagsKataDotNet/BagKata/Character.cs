using System.Collections.Generic;
using System.Linq;

namespace BagKata
{
    public class Character
    {
        private readonly IBackpack _backpack;
        private readonly List<string> _items;
        private readonly IPrinter _printer;
        private IBag _bag;
        private readonly IBag _secondBag;

        public Character(IPrinter printer, IBackpack backpack, IBag bag, IBag _secondBag)
        {
            _printer = printer;
            _backpack = backpack;
            _bag = bag;
            this._secondBag = _secondBag;
            _items = new List<string>();
        }

        public void Add(string leather)
        {
            if (!_backpack.IsFull())
                _backpack.Add(leather);
            else if (!_bag.IsFull())
                _bag.Add(leather);
            else
                _secondBag.Add(leather);

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

        private static string PrintItems(IEnumerable<string> items) => string.Join(", ", items.Select(x => $"'{x}'"));

        private void PrintBackpack() => _printer.Print($"backpack = [{PrintItems(_items)}]");
    }
}
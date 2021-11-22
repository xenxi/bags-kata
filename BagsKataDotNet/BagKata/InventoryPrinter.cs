using System;
using System.Collections;
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

        public void Print(IEnumerable<IBag> bags)
        {
            foreach (var bag in bags)
            {
                var itemsString = string.Join(", ", bag.GetItems().Select(x => $"'{x}'"));
                var bagType = BagTypeToString(bag);
                _printer.Print($"{bagType} = [{itemsString}]");
            }
            //IEnumerable<string> items = bags.GetItems();

            //_printer.Print($"backpack = [{string.Join(", ", items.Select(x => $"'{x}'"))}]");

            //_printer.Print("bag_with_metals_category = []");
            //_printer.Print("bag_with_no_category = []");
            //_printer.Print("bag_with_weapons_category = []");
            //_printer.Print("bag_with_no_category = []");
        }

        private string CategoryToString(Category category) =>
            category switch
            {
                Category.Clothes => "clothes",
                Category.Herbs => "herbs",
                Category.Metals => "metals",
                Category.Weapons => "weapons",
                Category.NoCategory => "no_category",
                _ => string.Empty
            };

        private  string BagTypeToString(IBag bag) =>
            bag.GetType() == typeof(Backpack)
                ? "backpack"
                : $"bag_with_{CategoryToString(bag.Category)}";
    }
}
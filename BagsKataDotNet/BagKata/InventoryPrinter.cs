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

        public void Print(IList<IBag> bags)
        {
            foreach (var bag in bags)
            {
                var itemsString = string.Join(", ", bag.GetItems().Select(x => $"'{x}'"));
                var bagType = BagTypeToString(bag);
                var data = $"{bagType} = [{itemsString}]";
                _printer.Print(data);
            }
        }

        private string CategoryToString(Category category) =>
            category switch
            {
                Category.Clothes => "clothes",
                Category.Herbs => "herbs",
                Category.Metals => "metals",
                Category.Weapons => "weapons",
                Category.NoCategory => "no",
                _ => string.Empty
            };

        private  string BagTypeToString(IBag bag) =>
            bag.GetType() == typeof(Backpack)
                ? "backpack"
                : $"bag_with_{CategoryToString(bag.Category)}_category";
    }
}
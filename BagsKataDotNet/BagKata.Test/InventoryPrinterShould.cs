using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace BagKata.Test
{
    [TestFixture]
    public class InventoryPrinterShould
    {
        private InventoryPrinter _inventory;
        private IPrinter _printer;

        [Test]
        public void print_inventory_with_empty_bags()
        {
            var aGivenBags = new List<IBag>
            {
                new Backpack(),
                new Bag(Category.Metals),
                new Bag(Category.NoCategory),
                new Bag(Category.Weapons),
                new Bag(Category.NoCategory),
            };

            _inventory.Print(aGivenBags);

            Received.InOrder(() =>
            {
                _printer.Print("backpack = []");
                _printer.Print("bag_with_metals_category = []");
                _printer.Print("bag_with_no_category = []");
                _printer.Print("bag_with_weapons_category = []");
                _printer.Print("bag_with_no_category = []");
            });
        }

        [TestCase(Category.NoCategory, "bag_with_no_category = []")]
        [TestCase(Category.Metals, "bag_with_metals_category = []")]
        [TestCase(Category.Weapons, "bag_with_weapons_category = []")]
        [TestCase(Category.Clothes, "bag_with_clothes_category = []")]
        [TestCase(Category.Herbs, "bag_with_herbs_category = []")]
        public void print_bag_with_category(Category bagCategory, string expected)
        {
            _inventory.Print(new List<IBag> { new Bag(bagCategory) });

            _printer.Received(1).Print(expected);
        }

        [TestCase("Space Hampster", "backpack = ['Space Hampster']")]
        [TestCase("Space Tomato", "backpack = ['Space Tomato']")]
        public void print_one_item_in_the_backpack(string item, string printedBackpack)
        {
            var aGivenBackpack = new Backpack();
            aGivenBackpack.Add(item);

            _inventory.Print(new List<IBag>{aGivenBackpack});

            _printer.Received(1).Print(printedBackpack);
        }

        [Test]
        public void print_two_items_in_the_backpack()
        {
            var aGivenBackpack = new Backpack();
            aGivenBackpack.Add("anyItem");
            aGivenBackpack.Add("otherItem");

            _inventory.Print(new List<IBag> { aGivenBackpack });

            _printer.Received(1).Print("backpack = ['anyItem', 'otherItem']");
        }

        [SetUp]
        public void SetUp()
        {
            _printer = Substitute.For<IPrinter>();
            _inventory = new InventoryPrinter(_printer);
        }
    }
}
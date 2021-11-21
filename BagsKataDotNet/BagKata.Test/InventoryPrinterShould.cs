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
        public void print_empty_inventory()
        {
            var aGivenEmptyInventory = Substitute.For<IInventory>();

            _inventory.Print(aGivenEmptyInventory);

            Received.InOrder(() =>
            {
                _printer.Print("backpack = []");
                _printer.Print("bag_with_metals_category = []");
                _printer.Print("bag_with_no_category = []");
                _printer.Print("bag_with_weapons_category = []");
                _printer.Print("bag_with_no_category = []");
            });
        }

        [TestCase("Space Hampster", "backpack = ['Space Hampster']")]
        [TestCase("Space Tomato", "backpack = ['Space Tomato']")]
        public void print_one_item_in_the_backpack(string item, string printedBackpack)
        {
            var aGivenInventoryWithOneItem = Substitute.For<IInventory>();
            aGivenInventoryWithOneItem.GetItems().Returns(new List<string> { item });

            _inventory.Print(aGivenInventoryWithOneItem);

            _printer.Received(1).Print(printedBackpack);
        }

        [Test]
        public void print_two_items_in_the_backpack()
        {
            var aGivenInventoryWithTwoItems = Substitute.For<IInventory>();
            aGivenInventoryWithTwoItems.GetItems().Returns(new List<string> { "anyItem", "otherItem" });

            _inventory.Print(aGivenInventoryWithTwoItems);

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
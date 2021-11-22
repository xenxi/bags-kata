using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class CharacterFeatured
    {
        private IPrinter _printer;
        private InventoryPrinter _inventoryPrinter;
        private Backpack _backpack;
        private Bag _bag;
        private Bag _secondBag;
        private Character _durance;

        [SetUp]
        public void SetUp()
        {
            _printer = Substitute.For<IPrinter>();
            _inventoryPrinter = new InventoryPrinter(_printer);
            _backpack = new Backpack();
            _bag = new Bag();
            _secondBag = new Bag();
            _durance = new Character(_inventoryPrinter, new Inventory(new List<IBag> { _backpack, _bag, _secondBag }));
        }
        [Test]
        public void print_full_backpack()
        {
            _durance.Add("Leather");
            _durance.Add("Iron");
            _durance.Add("Copper");
            _durance.Add("Marigold");
            _durance.Add("Wool");
            _durance.Add("Gold");
            _durance.Add("Silk");
            _durance.Add("Copper");

            _durance.PrintInventory();

            Received.InOrder(() =>
            {
                _printer.Print("backpack = ['Leather', 'Iron', 'Copper', 'Marigold', 'Wool', 'Gold', 'Silk', 'Copper']");
                _printer.Print("bag_with_metals_category = []");
                _printer.Print("bag_with_no_category = []");
                _printer.Print("bag_with_weapons_category = []");
                _printer.Print("bag_with_no_category = []");
            });
        }

        [Test]
        public void print_full_backpack_with_two_items_in_the_following_bag()
        {
            _durance.Add("Leather");
            _durance.Add("Iron");
            _durance.Add("Copper");
            _durance.Add("Marigold");
            _durance.Add("Wool");
            _durance.Add("Gold");
            _durance.Add("Silk");
            _durance.Add("Copper");
            _durance.Add("Copper");
            _durance.Add("Cherry Blossom");

            _durance.PrintInventory();

            Received.InOrder(() =>
            {
                _printer.Print("backpack = ['Leather', 'Iron', 'Copper', 'Marigold', 'Wool', 'Gold', 'Silk', 'Copper']");
                _printer.Print("bag_with_metals_category = ['Copper', 'Cherry Blossom']");
                _printer.Print("bag_with_no_category = []");
                _printer.Print("bag_with_weapons_category = []");
                _printer.Print("bag_with_no_category = []");
            });
        }
    }
}


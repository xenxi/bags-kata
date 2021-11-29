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
        private Character _durance;

        [SetUp]
        public void SetUp()
        {
            _printer = Substitute.For<IPrinter>();
            _inventoryPrinter = new InventoryPrinter(_printer);
            var bags = new List<IBag>
            {
                new Backpack(),
                new Bag(Category.Metals),
                new Bag(Category.NoCategory),
                new Bag(Category.Weapons),
                new Bag(Category.NoCategory),
            };

            _durance = new Character(_inventoryPrinter, new Inventory(bags), new SortSpell());
        }
        [Test]
        public void print_full_backpack()
        {
            _durance.Add(ItemMother.Ramdom(name: "Leather"));
            _durance.Add(ItemMother.Ramdom(name: "Iron"));
            _durance.Add(ItemMother.Ramdom(name: "Copper"));
            _durance.Add(ItemMother.Ramdom(name: "Marigold"));
            _durance.Add(ItemMother.Ramdom(name: "Wool"));
            _durance.Add(ItemMother.Ramdom(name: "Gold"));
            _durance.Add(ItemMother.Ramdom(name: "Silk"));
            _durance.Add(ItemMother.Ramdom(name: "Copper"));

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
            _durance.Add(ItemMother.Ramdom(name: "Leather"));
            _durance.Add(ItemMother.Ramdom(name: "Iron"));
            _durance.Add(ItemMother.Ramdom(name: "Copper"));
            _durance.Add(ItemMother.Ramdom(name: "Marigold"));
            _durance.Add(ItemMother.Ramdom(name: "Wool"));
            _durance.Add(ItemMother.Ramdom(name: "Gold"));
            _durance.Add(ItemMother.Ramdom(name: "Silk"));
            _durance.Add(ItemMother.Ramdom(name: "Copper"));
            _durance.Add(ItemMother.Ramdom(name: "Copper"));
            _durance.Add(ItemMother.Ramdom(name: "Cherry Blossom"));

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
        [Test]
        public void print_organizing_item_after_cast_spell()
        {
            _durance.Add(ItemMother.Ramdom(name: "Leather"));
            _durance.Add(ItemMother.Ramdom(name: "Iron"));
            _durance.Add(ItemMother.Ramdom(name: "Copper"));
            _durance.Add(ItemMother.Ramdom(name: "Marigold"));
            _durance.Add(ItemMother.Ramdom(name: "Wool"));
            _durance.Add(ItemMother.Ramdom(name: "Gold"));
            _durance.Add(ItemMother.Ramdom(name: "Silk"));
            _durance.Add(ItemMother.Ramdom(name: "Copper"));
            _durance.Add(ItemMother.Ramdom(name: "Copper"));
            _durance.Add(ItemMother.Ramdom(name: "Cherry Blossom"));
            _durance.SortInventory();

            _durance.PrintInventory();

            Received.InOrder(() =>
            {
                _printer.Print("backpack = ['Cherry Blossom', 'Iron', 'Leather', 'Marigold', 'Silk', 'Wool']");
                _printer.Print("bag_with_metals_category = ['Copper', 'Copper', 'Copper', 'Gold']");
                _printer.Print("bag_with_no_category = []");
                _printer.Print("bag_with_weapons_category = []");
                _printer.Print("bag_with_no_category = []");
            });
        }
    }
}


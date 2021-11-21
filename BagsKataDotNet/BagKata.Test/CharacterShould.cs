using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class CharacterShould
    {
        private Character _durance;
        private IPrinter _printer;
        private IInventory _inventory;
        [Test]
        public void add_item_to_inventory()
        {
            var aGivenItem = "anyItem";

            _durance.Add(aGivenItem);

            _inventory.Received(1).Add(aGivenItem);
        }
        [Test]
        public void print_empty_inventory()
        {
            _durance.PrintInventory();

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
            _durance.Add(item);

            _durance.PrintInventory();

            _printer.Received(1).Print(printedBackpack);
        }

        [Test]
        public void print_two_items_in_the_backpack()
        {
            _durance.Add("anyItem");
            _durance.Add("otherItem");

            _durance.PrintInventory();

            _printer.Received(1).Print("backpack = ['anyItem', 'otherItem']");
        }

        [SetUp]
        public void SetUp()
        {
            _printer = Substitute.For<IPrinter>();
            _inventory = Substitute.For<IInventory>();
            _durance = new Character(_printer, _inventory);
        }
    }
}
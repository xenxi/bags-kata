using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class CharacterShould
    {
        private Character _durance;
        private IInventoryPrinter _printer;
        private IInventory _inventory;
        private ISortSpell _sortSpell;

        [Test]
        public void add_item_to_inventory()
        {
            var aGivenItem = "anyItem";

            _durance.Add(aGivenItem);

            _inventory.Received(1).Add(aGivenItem);
        }

        [Test]
        public void print_inventory()
        {
            _durance.PrintInventory();

            _printer.Received(1).Print(_inventory.GetBags());
        }

        [Test]
        public void cast_the_sort_spell()
        {
            _durance.SortInventory();

            _sortSpell.Received(1).Cast();
        }

        [SetUp]
        public void SetUp()
        {
            _sortSpell = Substitute.For<ISortSpell>();
            _printer = Substitute.For<IInventoryPrinter>();
            _inventory = Substitute.For<IInventory>();
            _durance = new Character(_printer, _inventory, _sortSpell);
        }
    }
}
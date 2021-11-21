using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class InventoryShould
    {
        private IBackpack _backpack;
        private IBag _bag;
        private IBag _secondBag;
        private IInventory _inventory;

        [SetUp]
        public void SetUp()
        {
            _backpack = Substitute.For<IBackpack>();
            _bag = Substitute.For<IBag>();
            _secondBag = Substitute.For<IBag>();
            _inventory = new Inventory(_backpack, _bag, _secondBag);
        }

        [Test]
        public void add_item_to_the_backpack()
        {
            var aGivenAnyItem = "anyItem";

            _inventory.Add(aGivenAnyItem);

            _backpack.Received(1).Add(aGivenAnyItem);
        }

        [Test]
        public void add_item_to_the_next_bag_when_previous_ones_are_full()
        {
            var aGivenAnyItem = "anyItem";
            _backpack.IsFull().Returns(true);
            _bag.IsFull().Returns(true);
            _inventory.Add(aGivenAnyItem);

            _secondBag.Received(1).Add(aGivenAnyItem);
        }
        [Test]
        public void add_item_to_the_bag_when_backpack_is_full()
        {
            var aGivenAnyItem = "anyItem";
            _backpack.IsFull().Returns(true);
            _inventory.Add(aGivenAnyItem);

            _bag.Received(1).Add(aGivenAnyItem);
        }
    }
}

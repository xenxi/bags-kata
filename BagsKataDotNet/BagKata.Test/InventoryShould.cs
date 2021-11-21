using System;
using System.Collections.Generic;
using System.Text;
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
        private Inventory _inventory;

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
    }
}

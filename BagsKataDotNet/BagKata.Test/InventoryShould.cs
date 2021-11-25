using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class InventoryShould
    {
        private IBag _backpack;
        private IBag _bag;
        private IBag _secondBag;
        private Inventory _inventory;

        [SetUp]
        public void SetUp()
        {
            _backpack = Substitute.For<IBag>();
            _bag = Substitute.For<IBag>();
            _secondBag = Substitute.For<IBag>();
            _inventory = new Inventory(new List<IBag>{ _backpack, _bag, _secondBag });
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

        [Test]
        public void no_allow_add_new_item_when_its_full()
        {
            const string aGivenAnyItem = "anyItem";
            _backpack.IsFull().Returns(true);
            _bag.IsFull().Returns(true);
            _secondBag.IsFull().Returns(true);

            Action action = () => _inventory.Add(aGivenAnyItem);

            action.Should().Throw<InvalidOperationException>();
        }
        [Test]
        public void be_empty_when_all_bags_are_empty()
        {
            _backpack.IsEmpty().Returns(true);
            _bag.IsEmpty().Returns(true);
            _secondBag.IsEmpty().Returns(true);

            _inventory.IsEmpty().Should().BeTrue();
        }

    }
}

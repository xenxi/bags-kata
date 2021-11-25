using FluentAssertions;
using NUnit.Framework;
using System;

namespace BagKata.Test
{
    [TestFixture]
    public class BackpackShould
    {
        private Backpack _backpack;

        [Test]
        public void be_full_when_add_8_items()
        {
            var isFull = AGivenFullBackpack().IsFull();

            isFull.Should().BeTrue();
        }

        [Test]
        public void be_not_full_when_its_empty()
        {
            _backpack.IsFull().Should().BeFalse();
        }

        [Test]
        public void has_0_free_slots_when_add_8_items()
        {
            var freeSlots = AGivenFullBackpack().FreeSlots();

            freeSlots.Should().Be(0);
        }

        [Test]
        public void has_4_free_slots_when_its_empty()
        {
            _backpack.FreeSlots().Should().Be(8);
        }

        [Test]
        public void has_7_free_slots_when_add_1_item()
        {
            _backpack.Add("anyItem");

            _backpack.FreeSlots().Should().Be(7);
        }

        [Test]
        public void no_allow_add_new_item_when_its_full()
        {
            var aGivenFullBackpack = AGivenFullBackpack();

            Action action = () => aGivenFullBackpack.Add("anyOtherItem");

            action.Should().Throw<InvalidOperationException>();
        }

        [SetUp]
        public void SetUp()
        {
            _backpack = new Backpack();
        }

        [Test]
        public void store_a_item()
        {
            const string aGivenItem = "anyItem";

            _backpack.Add(aGivenItem);

            _backpack.GetItems().Should().ContainSingle(aGivenItem);
        }
        [Test]
        public void be_empty_when_no_has_items() {
            var bag = new Bag(Category.NoCategory);

            bag.IsEmpty().Should().BeTrue();
        }
        private static Backpack AGivenFullBackpack()
        {
            var backpack = new Backpack();
            for (int i = 0; i < 8; i++)
                backpack.Add("anyItem");
            return backpack;
        }
    }
}
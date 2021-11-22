using System;
using FluentAssertions;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class BackpackShould
    {
        [Test]
        public void store_a_item()
        {
            var aGivenItem = "anyItem";
            var bag = new Backpack();

            bag.Add(aGivenItem);

            bag.GetItems().Should().ContainSingle(aGivenItem);
        }
        [Test]
        public void has_4_free_slots_when_its_empty()
        {
            var bag = new Backpack();
            
            bag.FreeSlots().Should().Be(8);
        }

        [Test]
        public void be_not_full_when_its_empty()
        {
            var bag = new Backpack();

            bag.IsFull().Should().BeFalse();
        }
        [Test]
        public void has_7_free_slots_when_add_1_item()
        {
            var bag = new Backpack();

            bag.Add("anyItem");

            bag.FreeSlots().Should().Be(7);
        }

        [Test]
        public void has_0_free_slots_when_add_8_items()
        {
            var bag = AGivenFullBackpack();

            var freeSlots = bag.FreeSlots();

            freeSlots.Should().Be(0);
        }

        [Test]
        public void be_full_when_add_8_items()
        {
            var bag = AGivenFullBackpack();

            var isFull = bag.IsFull();

            isFull.Should().BeTrue();
        }

        private static Backpack AGivenFullBackpack()
        {
            var bag = new Backpack();
            for (int i = 0; i < 8; i++)
                bag.Add("anyItem");
            return bag;
        }

        [Test]
        public void no_allow_add_new_item_when_its_full()
        {
            var bag = new Backpack();
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");

            Action action = () => bag.Add("anyOtherItem");

            action.Should().Throw<InvalidOperationException>();
        }
    }
}

using System;
using FluentAssertions;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class BagShould
    {
        [Test]
        public void store_a_item()
        {
            var aGivenItem = "anyItem";
            var bag = new Bag(Category.NoCategory);

            bag.Add(aGivenItem);

            bag.GetItems().Should().ContainSingle(aGivenItem);
        }
        [Test]
        public void has_4_free_slots_when_its_empty()
        {
            var bag = new Bag(Category.NoCategory);
            
            bag.FreeSlots().Should().Be(4);
        }

        [Test]
        public void be_not_full_when_its_empty()
        {
            var bag = new Bag(Category.NoCategory);

            bag.IsFull().Should().BeFalse();
        }
        [Test]
        public void has_3_free_slots_when_add_1_item()
        {
            var bag = new Bag(Category.NoCategory);

            bag.Add("anyItem");

            bag.FreeSlots().Should().Be(3);
        }

        [Test]
        public void has_0_free_slots_when_add_4_items()
        {
            var bag = new Bag(Category.NoCategory);
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");

            bag.Add("anyItem");

            bag.FreeSlots().Should().Be(0);
        }

        [Test]
        public void be_full_when_not_have_free_slots()
        {
            var bag = new Bag(Category.NoCategory);
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");

            bag.Add("anyItem");

            bag.IsFull().Should().BeTrue();
        }

        [Test]
        public void no_allow_add_new_item_when_its_full()
        {
            var bag = new Bag(Category.NoCategory);
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");
            bag.Add("anyItem");

            Action action = () => bag.Add("anyOtherItem");

            action.Should().Throw<InvalidOperationException>();
        }
    }
}

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
            var bag = new Bag();

            bag.Add(aGivenItem);

            bag.GetItems().Should().ContainSingle(aGivenItem);
        }
        [Test]
        public void has_4_free_slots_when_its_empty()
        {
            var bag = new Bag();
            
            bag.FreeSlots().Should().Be(4);
        }

    }
}

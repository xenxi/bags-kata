using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace BagKata.Test
{
    [TestFixture]
    public class SortSpellShould
    {
        [Test]
        public void leave_the_inventory_empty_when_casting_spell_and_inventory_has_no_items() {
            var spell = new SortSpell();
            var bags = new List<IBag> { new Backpack() };
            var aGivenInventory = new Inventory(bags);
            
            var sortedInventory = spell.Cast(aGivenInventory);

            sortedInventory.IsEmpty().Should().BeTrue();
        }
    }
}

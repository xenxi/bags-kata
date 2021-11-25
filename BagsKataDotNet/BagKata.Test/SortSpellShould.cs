using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class SortSpellShould
    {
        [Test]
        public void leave_the_inventory_empty_when_casting_spell_and_inventory_has_no_items() {
            var spell = new SortSpell();
            var aGivenInventory = Substitute.For<IInventory>();
            
            var sortedInventory = spell.Cast(aGivenInventory);

            sortedInventory.IsEmpty().Should().BeTrue();
        }
    }
}

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

        [Test]
        public void moves_items_from_backpack_to_bag_with_item_category()
        {
            var spell = new SortSpell();
            var backpack = new Backpack();
            var herbsBag = new Bag(Category.Herbs);
            var bags = new List<IBag> { backpack, herbsBag };

            var aGivenInventory = new Inventory(bags);
            aGivenInventory.Add(ItemMother.Ramdom(category: Category.Herbs));

            var sortedInventory = spell.Cast(aGivenInventory);

            sortedInventory.IsEmpty().Should().BeTrue();
        }
    }
}

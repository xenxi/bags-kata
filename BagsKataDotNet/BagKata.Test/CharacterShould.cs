using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class CharacterShould
    {
        [Test]
        public void print_empty_inventory()
        {
            var printer = Substitute.For<IPrinter>();
            var durance = new Character(printer);

            durance.PrintInventory();

            Received.InOrder(() =>
            {
                printer.Print("backpack = []");
                printer.Print("bag_with_metals_category = []");
                printer.Print("bag_with_no_category = []");
                printer.Print("bag_with_weapons_category = []");
                printer.Print("bag_with_no_category = []");
            });

        }


        [TestCase("Space Hampster", "backpack = ['Space Hampster']")]
        [TestCase("Space Tomato", "backpack = ['Space Tomato']")]
        public void print_one_item_in_the_backpack(string item, string printedBackpack)
        {
            var printer = Substitute.For<IPrinter>();
            var durance = new Character(printer);
            durance.Add(item);

            durance.PrintInventory();

            printer.Received(1).Print(printedBackpack);
        }
        [Test]
        public void print_two_items_in_the_backpack()
        {
            var printer = Substitute.For<IPrinter>();
            var durance = new Character(printer);
            durance.Add("anyItem");
            durance.Add("otherItem");

            durance.PrintInventory();

            printer.Received(1).Print("backpack = ['anyItem', 'otherItem']");
        }
    }
}

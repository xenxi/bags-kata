using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class CharacterFeatured
    {
        [Test]
        public void print_full_backpack()
        {
            var printer = Substitute.For<IPrinter>();
            var durance = new Character(printer);
            durance.Add("Leather");
            durance.Add("Iron");
            durance.Add("Copper");
            durance.Add("Marigold");
            durance.Add("Wool");
            durance.Add("Gold");
            durance.Add("Silk");
            durance.Add("Copper");

            durance.PrintInventory();

            Received.InOrder(() =>
            {
                printer.Print("backpack = ['Leather', 'Iron', 'Copper', 'Marigold', 'Wool', 'Gold', 'Silk', 'Copper']");
                printer.Print("bag_with_metals_category = []");
                printer.Print("bag_with_no_category = []");
                printer.Print("bag_with_weapons_category = []");
                printer.Print("bag_with_no_category = []");
            });
        }
    }
}


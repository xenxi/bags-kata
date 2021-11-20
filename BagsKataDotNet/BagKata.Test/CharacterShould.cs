using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

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

        [Test]
        public void print_one_item_in_the_backpack()
        {
            var printer = Substitute.For<IPrinter>();
            var durance = new Character(printer);
            durance.Add("Space Hampster");

            durance.PrintInventory();

            printer.Received(1).Print("backpack = ['Space Hampster']");
        }

        [Test]
        public void print_other_item_in_the_backpack()
        {
            var printer = Substitute.For<IPrinter>();
            var durance = new Character(printer);
            durance.Add("Space Tomato");

            durance.PrintInventory();

            printer.Received(1).Print("backpack = ['Space Tomato']");
        }
    }
}

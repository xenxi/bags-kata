using NSubstitute;
using NUnit.Framework;

namespace BagKata.Test
{
    [TestFixture]
    public class CharacterShould
    {
        private Character _durance;
        private IPrinter _printer;
        private IInventory _inventory;
        [Test]
        public void add_item_to_inventory()
        {
            var aGivenItem = "anyItem";

            _durance.Add(aGivenItem);

            _inventory.Received(1).Add(aGivenItem);
        }
      

        [SetUp]
        public void SetUp()
        {
            _printer = Substitute.For<IPrinter>();
            _inventory = Substitute.For<IInventory>();
            _durance = new Character(_printer, _inventory);
        }
    }
}
namespace BagKata
{
    public class Character
    {
        private readonly IInventory _inventory;
        private readonly IInventoryPrinter _inventoryPrinter;

        public Character(IInventoryPrinter printer, IInventory inventory)
        {
            _inventory = inventory;
            _inventoryPrinter = printer;
        }

        public void Add(string leather) => _inventory.Add(leather);

        public void PrintInventory() => _inventoryPrinter.Print(_inventory.GetBags());
    }
}
namespace BagKata
{
    public class Character
    {
        private readonly IInventory _inventory;
        private readonly InventoryPrinter _inventoryPrinter;
        private readonly IPrinter _printer;
        public Character(IPrinter printer, IInventory inventory)
        {
            _printer = printer;
            _inventory = inventory;
            _inventoryPrinter = new InventoryPrinter(_printer);
        }

        public void Add(string leather) => _inventory.Add(leather);

        public void PrintInventory()
        {
            _inventoryPrinter.printInventory(_inventory);
        }
    }
}
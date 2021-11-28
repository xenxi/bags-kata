namespace BagKata
{
    public class Character
    {
        private readonly IInventoryPrinter _inventoryPrinter;
        private readonly ISortSpell _sortSpell;
        private IInventory _inventory;
        public Character(IInventoryPrinter printer, IInventory inventory, ISortSpell sortSpell)
        {
            _inventory = inventory;
            _inventoryPrinter = printer;
            _sortSpell = sortSpell;
        }

        public void Add(string leather) => _inventory.Add(leather);

        public void PrintInventory() => _inventoryPrinter.Print(_inventory.GetBags());

        public void SortInventory() => _inventory = _sortSpell.Cast(_inventory);
    }
}
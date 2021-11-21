namespace BagKata
{
    public class Character
    {
        private readonly IInventory _inventory;
        private readonly StringPrinter _stringPrinter;

        public Character(IPrinter printer, IInventory inventory)
        {
            _inventory = inventory;
            _stringPrinter = new StringPrinter(printer);
        }

        public void Add(string leather) => _inventory.Add(leather);

        public void PrintInventory() => _stringPrinter.printInventory(_inventory);
    }
}
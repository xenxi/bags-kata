﻿namespace BagKata
{
    public class Character
    {
        private readonly IInventory _inventory;
        private readonly InventoryPrinter _inventoryPrinter;

        public Character(IPrinter printer, IInventory inventory)
        {
            _inventory = inventory;
            _inventoryPrinter = new InventoryPrinter(printer);
        }

        public void Add(string leather) => _inventory.Add(leather);

        public void PrintInventory() => _inventoryPrinter.printInventory(_inventory);
    }
}
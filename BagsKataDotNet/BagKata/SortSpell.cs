namespace BagKata
{
    public class SortSpell : ISortSpell
    {
        public IInventory Cast(IInventory inventory)
        {
            return inventory;
        }
    }
}
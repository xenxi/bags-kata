namespace BagKata
{
    public class Character
    {
        private readonly IPrinter _printer;

        public Character(IPrinter printer)
        {
            _printer = printer;
        }

        public void Add(string leather)
        {
        }

        public void PrintInventory()
        {
            _printer.Print("backpack = []");
            _printer.Print("bag_with_metals_category = []");
            _printer.Print("bag_with_no_category = []");
            _printer.Print("bag_with_weapons_category = []");
            _printer.Print("bag_with_no_category = []");
        }
    }
}
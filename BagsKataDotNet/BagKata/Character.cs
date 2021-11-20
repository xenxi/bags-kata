namespace BagKata
{
    public class Character
    {
        private IPrinter printer;

        public Character(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Add(string leather)
        {
        }

        public void PrintInventory()
        {
            printer.Print("backpack = []");
            printer.Print("bag_with_metals_category = []");
            printer.Print("bag_with_no_category = []");
            printer.Print("bag_with_weapons_category = []");
            printer.Print("bag_with_no_category = []");
        }
    }
}
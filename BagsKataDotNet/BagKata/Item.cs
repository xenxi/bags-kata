namespace BagKata
{
    public class Item
    {
        public Item(string name, Category category)
        {
            Name = name;
            Category = category;
        }

        public string Name { get; }
        public Category Category { get; }
    }
}

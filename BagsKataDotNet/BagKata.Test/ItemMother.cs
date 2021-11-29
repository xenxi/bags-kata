using Bogus;
namespace BagKata.Test
{
    public static class ItemMother
    {
        private static Faker _faker = new Faker();
        public static Item Create(string name, Category category)
        => new Item(name, category);

        public static Item Ramdom(string name = null , Category? category = null) 
            => Create(name ?? _faker.Lorem.Slug(), category ?? _faker.PickRandom<Category>());
    }
}

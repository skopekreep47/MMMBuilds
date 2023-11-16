namespace MMMBuilds.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Alpha Name", Description="AAA AAA AAA"},
                new Category{CategoryId=2, CategoryName="Bravo Name", Description="BBB BBB BBB"},
                new Category{CategoryId=3, CategoryName="Charlie Name", Description="CCC CCC CCC"}
            };
    }
}

namespace MMMBuilds.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly MMMBuildsDbContext _mMMBuildsDbContext;
        public CategoryRepository(MMMBuildsDbContext mMMBuildsDbContext)
        {
            _mMMBuildsDbContext = mMMBuildsDbContext;
        }

        public IEnumerable<Category> AllCategories => _mMMBuildsDbContext.Categories.OrderBy(m => m.CategoryName);
    }
}

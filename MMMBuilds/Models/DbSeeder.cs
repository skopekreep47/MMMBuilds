using System.IO.Pipelines;

namespace MMMBuilds.Models
{
    public static class DbSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            MMMBuildsDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MMMBuildsDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Mechs.Any())
            {
                context.AddRange
                (
                    new Mechanism { Name = "Schmidt Coupling", Price = 115.95M, ShortDescription = "Lorem Ipsum", LongDescription = "The equations of translational kinematics can easily be extended to planar rotational kinematics for constant angular acceleration with simple variable exchanges.", Category = Categories["Alpha"], ImageUrl = "images/mech_schmidt.jpg", InStock = true, IsMechOfTheWeek = false, ImageThumbUrl = "images/mech_schmidt.jpg"},
                    new Mechanism { Name = "Geneva Drive", Price = 118.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Although position in space and velocity in space are both true vectors (in terms of their properties under rotation), as is angular velocity, angle itself is not a true vector.", Category = Categories["Bravo"], ImageUrl = "images/mech_geneva.jpg", InStock = true, IsMechOfTheWeek = false, ImageThumbUrl = "images/mech_geneva.jpg" }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Alpha" },
                        new Category { CategoryName = "Bravo" },
                        new Category { CategoryName = "Charlie" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}

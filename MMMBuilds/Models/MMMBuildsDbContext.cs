using Microsoft.EntityFrameworkCore;

namespace MMMBuilds.Models
{
    public class MMMBuildsDbContext: DbContext
    {
        public MMMBuildsDbContext(DbContextOptions<MMMBuildsDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Mechanism> Mechs { get; set; }
    }
}

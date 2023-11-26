using Microsoft.EntityFrameworkCore;

namespace MMMBuilds.Models
{
    public class MechRepository : IMechRepository
    {
        private readonly MMMBuildsDbContext _mMMBuildsDbContext;

        public MechRepository(MMMBuildsDbContext mMMBuildsDbContext)
        {
            _mMMBuildsDbContext = mMMBuildsDbContext;
        }

        public IEnumerable<Mechanism> AllMechs
        {
            get
            {
                return _mMMBuildsDbContext.Mechs.Include(c => c.Category);
            }
        }

        public IEnumerable<Mechanism> MechsOfTheWeek
        {
            get
            {
                return _mMMBuildsDbContext.Mechs.Include(c => c.Category).Where(m => m.IsMechOfTheWeek);
            }
        }

        public Mechanism? GetMechById(int mechId)
        {
            return _mMMBuildsDbContext.Mechs.FirstOrDefault(m => m.MechId == mechId);
        }
    }
}

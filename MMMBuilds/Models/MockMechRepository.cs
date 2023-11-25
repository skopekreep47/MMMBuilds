using System.IO.Pipelines;
using static System.Net.Mime.MediaTypeNames;

namespace MMMBuilds.Models
{
    public class MockMechRepository:IMechRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Mechanism> AllMechs =>
            new List<Mechanism>
            {
                new Mechanism {MechId = 1, Name="Schmidt Coupling", Price=115.95M, ShortDescription="Lorem Ipsum", LongDescription="The equations of translational kinematics can easily be extended to planar rotational kinematics for constant angular acceleration with simple variable exchanges.", Category = _categoryRepository.AllCategories.ToList()[0],ImageUrl="images/mech_schmidt.jpg", InStock=true, IsMechOfTheWeek=false, ImageThumbUrl="images/mech_schmidt.jpg"},
                new Mechanism {MechId = 2, Name="Geneva Drive", Price=118.95M, ShortDescription="Lorem Ipsum", LongDescription="Although position in space and velocity in space are both true vectors (in terms of their properties under rotation), as is angular velocity, angle itself is not a true vector.", Category = _categoryRepository.AllCategories.ToList()[1],ImageUrl="images/mech_geneva.jpg", InStock=true, IsMechOfTheWeek=false, ImageThumbUrl="images/mech_geneva.jpg"},
                new Mechanism {MechId = 3, Name="Scotch Yoke", Price=115.95M, ShortDescription="Lorem Ipsum", LongDescription="Important formulas in kinematics define the velocity and acceleration of points in a moving body as they trace trajectories in three-dimensional space.", Category = _categoryRepository.AllCategories.ToList()[0],ImageUrl="images/mech_scotch.jpg", InStock=true, IsMechOfTheWeek=true, ImageThumbUrl="images/mech_scotch.jpg"},
                new Mechanism {MechId = 4, Name="Rack and Pinion", Price=112.95M, ShortDescription="Lorem Ipsum", LongDescription="In order to define these formulas, the movement of a component B of a mechanical system is defined by the set of rotations.", Category = _categoryRepository.AllCategories.ToList()[2],ImageUrl="images/mech_rack.jpg", InStock=true, IsMechOfTheWeek=true, ImageThumbUrl="images/mech_rack.jpg"}
            };

        public IEnumerable<Mechanism> MechsOfTheWeek
        {
            get
            {
                return AllMechs.Where(p => p.IsMechOfTheWeek);
            }
        }

        public Mechanism? GetMechById(int mechId) => AllMechs.FirstOrDefault(p => p.MechId == mechId);

        public IEnumerable<Mechanism> SearchMechs(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}

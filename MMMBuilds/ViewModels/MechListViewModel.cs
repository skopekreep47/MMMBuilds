using MMMBuilds.Models;

namespace MMMBuilds.ViewModels
{
    public class MechListViewModel
    {
        public IEnumerable<Mechanism> Mechs { get; }
        public string? CurrentCategory { get; }

        public MechListViewModel(IEnumerable<Mechanism> mechs, string? currentCategory)
        {
            Mechs = mechs;
            CurrentCategory = currentCategory;
        }
    }
}

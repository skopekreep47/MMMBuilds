using MMMBuilds.Models;

namespace MMMBuilds.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Mechanism> MechsOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Mechanism> mechsOfTheWeek)
        {
            MechsOfTheWeek = mechsOfTheWeek;
        }
    }
}

namespace MMMBuilds.Models
{
    public interface IMechRepository
    {
        IEnumerable<Mechanism> AllMechs { get; }
        IEnumerable<Mechanism> MechsOfTheWeek { get; }

        Mechanism? GetMechById(int mechId);
    }
}

using BasePerson.Model.SimpleObjects;

namespace BasePerson.Model.AggregatedObjects
{
    public class Networking
    {
        public Networking(int personId, string fullName, IReadOnlyCollection<SimplePerson> colleagues, IReadOnlyCollection<SimplePerson> acquaintances, IReadOnlyCollection<SimplePerson> relatives)
        {
            PersonId = personId;
            FullName = fullName;
            Colleagues = colleagues;
            Acquaintances = acquaintances;
            Relatives = relatives;
        }
        public int PersonId { get; }
        public string FullName { get; }
        public IReadOnlyCollection<SimplePerson> Colleagues { get; }
        public IReadOnlyCollection<SimplePerson> Acquaintances { get; }
        public IReadOnlyCollection<SimplePerson> Relatives { get; }
    }
}

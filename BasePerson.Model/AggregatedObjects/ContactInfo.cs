using BasePerson.Model.SimpleObjects;

namespace BasePerson.Model.AggregatedObjects
{
    public class ContactInfo
    {
        public ContactInfo(int personId, string fullName, IReadOnlyCollection<SimplePhone> offices, IReadOnlyCollection<SimplePhone> homes, IReadOnlyCollection<SimplePhone> mobiles)
        {
            PersonId = personId;
            FullName = fullName;
            Offices = offices;
            Homes = homes;
            Mobiles = mobiles;
        }

        public int PersonId { get; }
        public string FullName { get; }
        public IReadOnlyCollection<SimplePhone> Offices { get; }
        public IReadOnlyCollection<SimplePhone> Homes { get; }
        public IReadOnlyCollection<SimplePhone> Mobiles { get; }

    }
}

using BasePerson.Model.Enums;

namespace BasePerson.Model.BusinessObjects
{
    public class ConnectedPerson : BusinessObject
    {
        public Person? Main { get; set; }
        public Person? Linked { get; set; }
        public ConnectionType Type { get; set; }
    }
}

using Person.Model.Enums;

namespace Person.Model.BusinessObjects
{
    public class ConnectedPerson : BusinessObject
    {
        public Person? Main { get; set; }
        public Person? Linked { get; set; }
        public ConnectionType Type { get; set; }
    }
}

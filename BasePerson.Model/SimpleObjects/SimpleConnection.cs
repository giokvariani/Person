using BasePerson.Model.BusinessObjects;

namespace BasePerson.Model.SimpleObjects
{
    public class SimpleConnection
    {
        public SimpleConnection(Person person, int connectionId)
        {
            ConnectionId = connectionId;
            Person = person;
        }
        public Person Person { get; }
        public int ConnectionId { get; }
    }
}

using BasePerson.Model.Enums;

namespace BasePerson.Model.SimpleObjects
{
    public class SimplePerson
    {
        public SimplePerson(string firstName, string lastName, ConnectionType connectionType, int connectionId, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            ConnectionType = connectionType;
            ConnectionId = connectionId;
            Id = id;
        }
        public int Id { get; }
        public int ConnectionId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public ConnectionType ConnectionType { get; }
    }
}

using BasePerson.Model.Enums;

namespace BasePerson.Model.SimpleObjects
{
    public class SimplePerson
    {
        public SimplePerson(string firstName, string lastName, ConnectionType connectionType, int connectionId)
        {
            FirstName = firstName;
            LastName = lastName;
            ConnectionType = connectionType;
            ConnectionId = connectionId;
        }
        public int ConnectionId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public ConnectionType ConnectionType { get; }
    }
}

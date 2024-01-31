using BasePerson.Model.Enums;

namespace BasePerson.Model.SimpleObjects
{
    public class SimplePhone
    {
        public int Id { get; }
        public int ConnectionId { get; }
        public string Number { get; }
        public SimplePhone(int id, string number, int connectionId)
        {
            Id = id;
            Number = number;
            ConnectionId = connectionId;
        }
    }
}

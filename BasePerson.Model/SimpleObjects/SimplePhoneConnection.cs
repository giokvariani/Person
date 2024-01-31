using BasePerson.Model.BusinessObjects;

namespace BasePerson.Model.SimpleObjects
{
    public class SimplePhoneConnection
    {
        public SimplePhoneConnection(Phone phone, int connectionId)
        {
            ConnectionId = connectionId;
            Phone = phone;
        }
        public Phone Phone { get; }
        public int ConnectionId { get; }
    }
}

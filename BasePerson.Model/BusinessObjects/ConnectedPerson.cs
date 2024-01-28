using BasePerson.Model.Enums;

namespace BasePerson.Model.BusinessObjects
{
    public class ConnectedPeople : BusinessObject
    {
        public int MainId { get; set; }
        public int LinkedId { get; set; }
        public ConnectionType Type { get; set; }
    }
}

using BasePerson.Model.Enums;

namespace BasePerson.Application.DTOs.Person
{
    public class ConnectedPeopleDto
    {
        public int MainId { get; set; }
        public int LinkedId { get; set; }
        public ConnectionType Type { get; set; }

    }
}

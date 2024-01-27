using BasePerson.Model.Enums;

namespace BasePerson.Application.DTOs.Person
{
    public class SetConnectedPersonDto
    {
        public ConnectionType ConnectionType { get; set; }
        public int BaseConnectedPersonId { get; set; }
    }
}

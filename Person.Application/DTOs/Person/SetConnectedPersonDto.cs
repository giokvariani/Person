using Person.Model.Enums;

namespace Person.Application.DTOs.Person
{
    public class SetConnectedPersonDto
    {
        public ConnectionType ConnectionType { get; set; }
        public int BaseConnectedPersonId { get; set; }
    }
}

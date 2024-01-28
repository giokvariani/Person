using BasePerson.Model.Enums;

namespace BasePerson.Application.DTOs.Phone
{
    public class PhoneDto
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
    }
}

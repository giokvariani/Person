using BasePerson.Model.Enums;

namespace BasePerson.Application.DTOs.Phone
{
    public class SetPhoneDto
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
    }
}

using Person.Model.Enums;

namespace Person.Application.DTOs.Phone
{
    public class SetPhoneDto
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
    }
}

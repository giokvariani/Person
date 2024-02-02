using BasePerson.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace BasePerson.Application.DTOs.Phone
{
    public class PhoneDto
    {
        public PhoneType Type { get; set; }
        [StringLength(50, MinimumLength = 4)]
        public string Number { get; set; }
    }
}

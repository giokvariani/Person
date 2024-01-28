using BasePerson.Model.Enums;

namespace BasePerson.Application.DTOs.Person
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
    }
}

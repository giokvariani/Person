using Person.Application.DTOs.City;
using Person.Model.Enums;

namespace Person.Application.DTOs.Person
{
    public class GetPersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PersonalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageAddress { get; set; }
        public GetCityDto City { get; set; }
    }
}

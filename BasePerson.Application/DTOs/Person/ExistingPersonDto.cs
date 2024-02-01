using BasePerson.Application.DTOs.City;

namespace BasePerson.Application.DTOs.Person
{
    public class ExistingPersonDto : PersonDto
    {
        public int Id { get; set; }
    }

    public class GetPersonDto : ExistingPersonDto
    {
        public CityDto City { get; set; }
    }
}

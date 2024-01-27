using Person.Application.DTOs.Person;

namespace Person.Application.DTOs
{
    public class GetConnectedPersonDto
    {
        public int Id { get; set; }
        public GetPersonDto Link { get; set; }
    }
}

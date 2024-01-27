namespace BasePerson.Application.DTOs.Person
{
    public class GetConnectedPersonDto
    {
        public int Id { get; set; }
        public GetPersonDto Link { get; set; }
    }
}

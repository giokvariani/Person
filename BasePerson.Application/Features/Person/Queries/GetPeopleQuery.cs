using BasePerson.Application.DTOs.Person;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Person.Queries
{
    public class GetPeopleQuery : IRequest<List<ExistingPersonDto>>
    {
        public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<ExistingPersonDto>>
        {
            private readonly IPersonRepository _personRepository;
            public GetPeopleQueryHandler(IPersonRepository personRepository) => _personRepository = personRepository;

            public async Task<List<ExistingPersonDto>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
            {
                var people = await _personRepository.ReadAsync();
                var existingPeople = people.Select(person => new ExistingPersonDto() { FirstName = person.FirstName, LastName = person.LastName, DateOfBirth = person.DateOfBirth, Gender = person.Gender, Id = person.Id, IDNumber = person.IDNumber, Image = person.Image }).ToList();
                return existingPeople;
            }
        }
    }
}

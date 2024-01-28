using BasePerson.Application.DTOs.Person;
using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Person.Queries
{
    public class GetPersonQuery : IRequest<ExistingPersonDto>
    {
        public int Id { get; set; }
        public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, ExistingPersonDto>
        {
            private readonly IPersonRepository _personRepository;
            public GetPersonQueryHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            public async Task<ExistingPersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.ReadAsync(request.Id);
                if (person == null)
                    throw new EntityNotFoundException();
                var existingPersonDto = new ExistingPersonDto() { FirstName = person.FirstName, LastName = person.LastName, DateOfBirth = person.DateOfBirth, Gender = person.Gender, Id = person.Id, IDNumber = person.IDNumber, Image = person.Image };
                return existingPersonDto;
            }
        }
    }
}

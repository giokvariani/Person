using BasePerson.Application.DTOs.Person;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Person
{
    public class CreatePersonCommand : IRequest<int>
    {
        public PersonDto PersonDto { get; set; }
        public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
        {
            private readonly IPersonRepository _personRepository;
            public CreatePersonCommandHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }
            public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
            {
                var personDto = request.PersonDto;
                var idNumber = personDto.IDNumber;
                var existingPerson = await _personRepository.ReadAsync(idNumber);
                if (existingPerson != null)
                    throw new InvalidOperationException($"Person: {idNumber} already exists.");

                var person = new Model.BusinessObjects.Person() { FirstName = personDto.FirstName, LastName = personDto.LastName, CreatedOn = DateTime.Now, DateOfBirth = personDto.DateOfBirth, Gender = personDto.Gender, IDNumber = idNumber, Image = personDto.Image };
                var result = await _personRepository.CreateAsync(person);
                return result;
            }
        }
    }
}

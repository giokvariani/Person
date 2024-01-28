using BasePerson.Application.DTOs.Person;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Person
{
    public class UpdatePersonCommand : IRequest<int>
    {
        public ExistingPersonDto PersonDto { get; set; }

        public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, int>
        {
            private readonly IPersonRepository _personRepository;
            public UpdatePersonCommandHandler(IPersonRepository personRepository) => _personRepository = personRepository;

            public async Task<int> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
            {
                var personDto = request.PersonDto;
                var idNumber = request.PersonDto.IDNumber;
                var samePerson = (await _personRepository.ReadAsync(x => x.IDNumber == idNumber)).SingleOrDefault();

                if (samePerson != null)
                    throw new InvalidOperationException($"Person: {idNumber} already exists! ID:{samePerson.Id}");

                var person = new Model.BusinessObjects.Person() { FirstName = personDto.FirstName, LastName = personDto.LastName, DateOfBirth = personDto.DateOfBirth, Gender = personDto.Gender, IDNumber = idNumber, Image = personDto.Image, UpdatedOn = DateTime.Now };
                var result = await _personRepository.UpdateAsync(personDto.Id, person);
                return result;
            }
        }
    }
}

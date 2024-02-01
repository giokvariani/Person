using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Person
{
    public class DeletePersonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, int>
        {
            private readonly IPersonRepository _personRepository;
            private readonly IConnectedPeopleRepository _connectedPeopleRepository;
            private readonly IPhone2PersonRepository _phone2PersonReposittory;
            public DeletePersonCommandHandler(IPersonRepository personRepository, IConnectedPeopleRepository connectedPeopleRepository, IPhone2PersonRepository phone2PersonReposittory)
            {
                _personRepository = personRepository;
                _connectedPeopleRepository = connectedPeopleRepository;
                _phone2PersonReposittory = phone2PersonReposittory;
            }
            public async Task<int> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
            {
                var personId = request.Id;
                var existingPerson = await _personRepository.ReadAsync(personId);
                if (existingPerson == null)
                    throw new EntityNotFoundException();


                var connectedPeople = (await _connectedPeopleRepository.ReadAsync(x => x.MainId == personId || x.LinkedId == personId)).ToList();
                await _connectedPeopleRepository.DeleteRangeAsync(connectedPeople);

                var phonesToPerson = (await _phone2PersonReposittory.ReadAsync(x => x.PersonId == request.Id)).ToList();
                await _phone2PersonReposittory.DeleteRangeAsync(phonesToPerson);

                var result = await _personRepository.DeleteAsync(personId);
                return result;
            }
        }
    }
}

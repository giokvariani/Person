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
            public DeletePersonCommandHandler(IPersonRepository personRepository, IConnectedPeopleRepository connectedPeopleRepository)
            {
                _personRepository = personRepository;
                _connectedPeopleRepository = connectedPeopleRepository;
            }
            public async Task<int> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
            {
                var personId = request.Id;
                var existingPerson = await _personRepository.ReadAsync(personId);
                if (existingPerson == null)
                    throw new EntityNotFoundException();


                var connectedPeople = (await _connectedPeopleRepository.ReadAsync(x => x.MainId == personId)).ToList();
                await _connectedPeopleRepository.DeleteRangeAsync(connectedPeople);

                var result = await _personRepository.DeleteAsync(personId);
                return result;
            }
        }
    }
}

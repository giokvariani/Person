using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using BasePerson.Model.Enums;
using MediatR;

namespace BasePerson.Application.Features.Person.Commands
{
    public class DisconnectPeopleCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DisconnectPeopleCommand(int id)
        {
            Id = id;
        }
        public class DisconnectPeopleCommandHandler : IRequestHandler<DisconnectPeopleCommand, int>
        {
            private readonly IConnectedPeopleRepository _connectedPeopleRepository;
            public DisconnectPeopleCommandHandler(IConnectedPeopleRepository connectedPeopleRepository)
            {
                _connectedPeopleRepository = connectedPeopleRepository;
            }
            public async Task<int> Handle(DisconnectPeopleCommand request, CancellationToken cancellationToken)
            {
                var mainPersonId = request.Id;
                var connectedPeople = await _connectedPeopleRepository.ReadAsync(mainPersonId);
                if (connectedPeople == null)
                    throw new EntityNotFoundException();

                var result = await _connectedPeopleRepository.DeleteAsync(mainPersonId);
                return result;
            }
        }
    }
}

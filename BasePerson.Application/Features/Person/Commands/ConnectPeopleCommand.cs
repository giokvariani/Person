using BasePerson.Application.DTOs.Person;
using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using MediatR;

namespace BasePerson.Application.Features.Person.Commands
{
    public class ConnectPeopleCommand : IRequest<int>
    {
        public ConnectedPeopleDto PeopleDto { get; set; }
        public ConnectPeopleCommand(ConnectedPeopleDto peopleDto)
        {
            PeopleDto = peopleDto;
        }

        public class ConnectPeopleCommandHandler : IRequestHandler<ConnectPeopleCommand, int>
        {
            private readonly IPersonRepository _personRepository;
            private readonly IConnectedPeopleRepository _connectedPeopleRepository;
            public ConnectPeopleCommandHandler(IConnectedPeopleRepository connectedPeopleRepository, IPersonRepository personRepository)
            {
                _connectedPeopleRepository = connectedPeopleRepository;
                _personRepository = personRepository;
            }

            public async Task<int> Handle(ConnectPeopleCommand request, CancellationToken cancellationToken)
            {
                var peopleDto = request.PeopleDto;

                var mainPerson = await _personRepository.ReadAsync(peopleDto.MainId);
                if (mainPerson == null)
                    throw new EntityNotFoundException($"PersonID: {peopleDto.MainId}");

                var linkedPerson = await _personRepository.ReadAsync(peopleDto.LinkedId);
                if (linkedPerson == null)
                    throw new EntityNotFoundException($"PersonID: {peopleDto.LinkedId}");
                
                var existingConnectedPeople = (await _connectedPeopleRepository.ReadAsync(x => x.MainId == peopleDto.MainId && x.LinkedId == peopleDto.LinkedId && x.Type == peopleDto.Type)).SingleOrDefault();
                if (existingConnectedPeople != null)
                    throw new InvalidOperationException($"Person: {peopleDto.MainId} and {peopleDto.LinkedId} are already {peopleDto.Type}.");


                var existingConnectedPeopleSecondOption = (await _connectedPeopleRepository.ReadAsync(x => x.LinkedId == peopleDto.MainId && x.MainId == peopleDto.LinkedId && x.Type == peopleDto.Type)).SingleOrDefault();
                if (existingConnectedPeopleSecondOption != null)
                    throw new InvalidOperationException($"Person: {peopleDto.MainId} and {peopleDto.LinkedId} are already {peopleDto.Type}.");

                var connectedPeople = new ConnectedPeople() { MainId = peopleDto.MainId, LinkedId = peopleDto.LinkedId, Type = peopleDto.Type, CreatedOn = DateTime.Now };
                var result = await _connectedPeopleRepository.CreateAsync(connectedPeople);
                return result;
            }
        }
    }
}
    
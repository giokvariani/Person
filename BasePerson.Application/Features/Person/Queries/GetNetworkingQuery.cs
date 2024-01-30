using BasePerson.Application.Exceptions;
using BasePerson.Application.ExtensionMethods;
using BasePerson.Application.Interfaces;
using BasePerson.Model.AggregatedObjects;
using BasePerson.Model.BusinessObjects;
using BasePerson.Model.SimpleObjects;
using MediatR;

namespace BasePerson.Application.Features.Person.Queries
{
    public class GetNetworkingQuery : IRequest<Networking>
    {
        public int Id { get; }
        public GetNetworkingQuery(int id) => Id = id;
        public class GetNetworkingQueryHandler : IRequestHandler<GetNetworkingQuery, Networking>
        {
            private readonly IPersonRepository _personRepository;
            private readonly IConnectedPeopleRepository _connectedPeopleRepository;
            public GetNetworkingQueryHandler(IPersonRepository personRepository, IConnectedPeopleRepository connectedPeopleRepository)
            {
                _personRepository = personRepository;
                _connectedPeopleRepository = connectedPeopleRepository;
            }
            private async Task<IReadOnlyCollection<SimplePerson>> GetSimplePeople(IReadOnlyCollection<ConnectedPeople> connectedPeopleCollection, Model.Enums.ConnectionType connectionType, int personId)
            {
                //foreach (var connectedPeople in connectedPeopleCollection)
                //{
                //    var mainIdIsPersonId = connectedPeople.MainId == personId;
                //    var linkedIdIsPersonId = connectedPeople.LinkedId == personId;

                    
                //}

                var specificTypePeople = connectedPeopleCollection.Where(x => x.Type == connectionType)
                    .Select(x => (x.LinkedId == personId ? x.MainId : x.LinkedId, x.Id))
                    .AsReadOnlyList();


                var simpleConnections = new List<SimpleConnection>();
                foreach (var specificPerson in specificTypePeople)
                {
                    var person = await _personRepository.ReadAsync(specificPerson.Item1);
                    var simpleConnection = new SimpleConnection(person, specificPerson.Id);
                    simpleConnections.Add(simpleConnection);
                }
                return simpleConnections.Select(x => new SimplePerson(x.Person.FirstName, x.Person.LastName, connectionType, x.ConnectionId, x.Person.Id)).AsReadOnlyList(); 
            }
            public async Task<Networking> Handle(GetNetworkingQuery request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.ReadAsync(request.Id);
                if (person == null)
                    throw new EntityNotFoundException();


                var connectedPeople = (await _connectedPeopleRepository.ReadAsync(x => x.MainId == person.Id || x.LinkedId == person.Id)).ToList();

                

                var relatives =  await GetSimplePeople(connectedPeople, Model.Enums.ConnectionType.Relative, request.Id);
                var acquaintances = await GetSimplePeople(connectedPeople, Model.Enums.ConnectionType.Acquaintance, request.Id);
                var colleagues = await GetSimplePeople(connectedPeople, Model.Enums.ConnectionType.Colleague, request.Id);

                var targetPerson = await _personRepository.ReadAsync(request.Id);

                var networking = new Networking(request.Id, $"{targetPerson.FirstName} {targetPerson.LastName}", colleagues, acquaintances, relatives);
                return networking;
            }
        }
    }
}

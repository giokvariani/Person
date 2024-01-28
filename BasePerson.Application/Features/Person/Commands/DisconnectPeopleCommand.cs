//using BasePerson.Application.Interfaces;
//using BasePerson.Model.Enums;
//using MediatR;

//namespace BasePerson.Application.Features.Person.Commands
//{
//    public class DisconnectPeopleCommand : IRequest<int>
//    {
//        public int Id { get; set; }
//        public DisconnectPeopleCommand(int id)
//        {
//            Id = id;
//        }
//        public class DisconnectPeopleCommandHandler : IRequestHandler<DisconnectPeopleCommand, int>
//        {
//            private readonly IConnectedPeopleRepository _connectedPeopleRepository;
//            public DisconnectPeopleCommandHandler(IConnectedPeopleRepository connectedPeopleRepository)
//            {
//                _connectedPeopleRepository = connectedPeopleRepository;
//            }
//            public Task<int> Handle(DisconnectPeopleCommand request, CancellationToken cancellationToken)
//            {

//            }
//        }
//    }
//}

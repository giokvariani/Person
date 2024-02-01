using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Person.Commands
{
    public class DeleteNumberCommand : IRequest<int>
    {
        public int ConnectionId { get; }

        public DeleteNumberCommand(int connectionId)
        {
            ConnectionId = connectionId;
        }

        public class DeleteNumberCommandHandler : IRequestHandler<DeleteNumberCommand, int>
        {
            private readonly IPhone2PersonRepository _phone2PersonRepository;
            public DeleteNumberCommandHandler(IPhone2PersonRepository phone2PersonRepository) => _phone2PersonRepository = phone2PersonRepository;
            public async Task<int> Handle(DeleteNumberCommand request, CancellationToken cancellationToken)
            {
                var phone2Person = await _phone2PersonRepository.ReadAsync(request.ConnectionId);
                if (phone2Person == null)
                    throw new EntityNotFoundException();

                var result = await _phone2PersonRepository.DeleteAsync(request.ConnectionId);
                return result;
            }
        }
    }
}

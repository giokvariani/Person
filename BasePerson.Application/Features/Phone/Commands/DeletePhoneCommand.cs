using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Phone.Commands
{
    public class DeletePersonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, int>
        {
            private readonly IPhoneRepository _phoneRepository;
            public DeletePersonCommandHandler(IPhoneRepository phoneRepository) => _phoneRepository = phoneRepository;

            public async Task<int> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
            {
                var phoneId = request.Id;
                var existingPhone = await _phoneRepository.ReadAsync(phoneId);
                if (existingPhone == null)
                    throw new EntityNotFoundException();
                var result = await _phoneRepository.DeleteAsync(phoneId);
                return result;
            }
        }
    }
}

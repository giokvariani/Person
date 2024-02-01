using BasePerson.Application.Exceptions;
using BasePerson.Application.ExtensionMethods;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Phone.Commands
{
    public class DeletePhoneCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePhoneCommandHandler : IRequestHandler<DeletePhoneCommand, int>
        {
            private readonly IPhoneRepository _phoneRepository;
            private readonly IPhone2PersonRepository _phone2PersonRepository;
            public DeletePhoneCommandHandler(IPhoneRepository phoneRepository, IPhone2PersonRepository phone2PersonRepository)
            {
                _phoneRepository = phoneRepository;
                _phone2PersonRepository = phone2PersonRepository;

            }

            public async Task<int> Handle(DeletePhoneCommand request, CancellationToken cancellationToken)
            {
                var phoneId = request.Id;
                var existingPhone = await _phoneRepository.ReadAsync(phoneId);
                if (existingPhone == null)
                    throw new EntityNotFoundException();

                var phone2Person = (await _phone2PersonRepository.ReadAsync(x => x.PhoneId == phoneId)).AsReadOnlyList();
                await _phone2PersonRepository.DeleteRangeAsync(phone2Person);

                var result = await _phoneRepository.DeleteAsync(phoneId);
                return result;
            }
        }
    }
}

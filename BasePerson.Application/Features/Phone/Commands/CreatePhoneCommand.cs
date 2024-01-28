using BasePerson.Application.DTOs.Phone;
using BasePerson.Application.Interfaces;
using MediatR;


namespace BasePerson.Application.Features.Phone.Commands
{
    public class CreatePhoneCommand : IRequest<int>
    {
        public PhoneDto PhoneDto { get; set; }
        public CreatePhoneCommand(PhoneDto phoneDto) => PhoneDto = phoneDto;
        public class CreatePhoneCommandHandler : IRequestHandler<CreatePhoneCommand, int>
        {
            private readonly IPhoneRepository _phoneRepository;
            public CreatePhoneCommandHandler(IPhoneRepository phoneRepository)
            {
                _phoneRepository = phoneRepository;
            }
            public async Task<int> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
            {
                var number = request.PhoneDto.Number;
                var existingPhone = await _phoneRepository.ReadAsync(number);
                if (existingPhone != null)
                    throw new InvalidOperationException($"Phone: {number} already exists.");

                var phone = new Model.BusinessObjects.Phone() { CreatedOn = DateTime.Now, Number = number };
                var result = await _phoneRepository.CreateAsync(phone);
                return result;
            }
        }
    }
}

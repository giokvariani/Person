using BasePerson.Application.DTOs.Phone;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Phone.Commands
{
    public class UpdatePhoneCommand : IRequest<int>
    {
        public ExistingPhoneDto PhoneDto { get; set; }
        public UpdatePhoneCommand(ExistingPhoneDto phoneDto)
        {
            PhoneDto = phoneDto;
        }
        public class UpdatePhoneCommandHandler : IRequestHandler<UpdatePhoneCommand, int>
        {
            private readonly IPhoneRepository _phoneRepository;
            public UpdatePhoneCommandHandler(IPhoneRepository phoneRepository) => _phoneRepository = phoneRepository;
            public async Task<int> Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
            {
                var phoneDto = request.PhoneDto;
                var samePhone = (await _phoneRepository.ReadAsync(x => x.Number == phoneDto.Number && x.Id != phoneDto.Id)).SingleOrDefault();

                if (samePhone != null)
                    throw new InvalidOperationException($"Phone: {samePhone.Number} already exists! ID:{samePhone.Id}");

                var phone = new Model.BusinessObjects.Phone() { Id = phoneDto.Id, Number = phoneDto.Number, Type = phoneDto.Type, UpdatedOn = DateTime.Now };
                var result = await _phoneRepository.UpdateAsync(phoneDto.Id, phone);
                return result;
            }
        }
    }
}

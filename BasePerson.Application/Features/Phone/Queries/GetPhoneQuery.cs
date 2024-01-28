using BasePerson.Application.DTOs.Phone;
using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Phone.Queries
{
    public class GetPhoneQuery : IRequest<PhoneDto>
    {
        public int Id { get; set; }
        public GetPhoneQuery(int id)
        {
            Id = id;
        }
        public class GetPhoneQueryHandler : IRequestHandler<GetPhoneQuery, PhoneDto>
        {
            private readonly IPhoneRepository _phoneRepository;
            public GetPhoneQueryHandler(IPhoneRepository phoneRepository) => _phoneRepository = phoneRepository;
            public async Task<PhoneDto> Handle(GetPhoneQuery request, CancellationToken cancellationToken)
            {
                var phone = await _phoneRepository.ReadAsync(request.Id);
                if (phone == null)
                    throw new EntityNotFoundException();
                var existingPersonDto = new ExistingPhoneDto() { Number = phone.Number, Type = phone.Type, Id = phone.Id };
                return existingPersonDto;
            }
        }
    }
}

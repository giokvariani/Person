using BasePerson.Application.DTOs.Phone;
using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Phone.Queries
{
    public class GetPhoneQuery : IRequest<PhoneDto>
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public GetPhoneQuery(int id)
        {
            Id = id;
            
        }
        public GetPhoneQuery(string? number)
        {
            Number = number;
            Id = -1;
        }
        public class GetPhoneQueryHandler : IRequestHandler<GetPhoneQuery, PhoneDto>
        {
            private readonly IPhoneRepository _phoneRepository;
            public GetPhoneQueryHandler(IPhoneRepository phoneRepository) => _phoneRepository = phoneRepository;
            public async Task<PhoneDto> Handle(GetPhoneQuery request, CancellationToken cancellationToken)
            {
                var phone = request.Number == null ? await _phoneRepository.ReadAsync(request.Id) : (await _phoneRepository.ReadAsync(x => x.Number == request.Number)).SingleOrDefault();
                if (phone == null)
                    throw new EntityNotFoundException();
                var existingPersonDto = new ExistingPhoneDto() { Number = phone.Number, Type = phone.Type, Id = phone.Id };
                return existingPersonDto;
            }
        }
    }
}

using BasePerson.Application.DTOs.Phone;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.Phone.Queries
{
    public class GetPhonesQuery : IRequest<List<ExistingPhoneDto>>
    {
        public class GetPhonesQueryHandler : IRequestHandler<GetPhonesQuery, List<ExistingPhoneDto>>
        {
            private readonly IPhoneRepository _phoneRepository;
            public GetPhonesQueryHandler(IPhoneRepository phoneRepository) => _phoneRepository = phoneRepository;
            public async Task<List<ExistingPhoneDto>> Handle(GetPhonesQuery request, CancellationToken cancellationToken)
            {
                var phones = await _phoneRepository.ReadAsync();
                var existingPhones = phones.Select(x => new ExistingPhoneDto() { Id = x.Id, Number = x.Number, Type = x.Type }).ToList();
                return existingPhones;
            }
        }
    }
}

using BasePerson.Application.DTOs.Phone;
using MediatR;

namespace BasePerson.Application.Features.Phone.Queries
{
    public class GetPhonesQuery : IRequest<List<ExistingPhoneDto>>
    {
        public class GetPhonesQueryHandler : IRequestHandler<GetPhonesQueryHandler, List<ExistingPhoneDto>>
        {

        }

    }
}

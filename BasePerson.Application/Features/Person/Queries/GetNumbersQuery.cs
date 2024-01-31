using BasePerson.Application.Exceptions;
using BasePerson.Application.ExtensionMethods;
using BasePerson.Application.Interfaces;
using BasePerson.Model.AggregatedObjects;
using BasePerson.Model.SimpleObjects;
using MediatR;

namespace BasePerson.Application.Features.Person.Queries
{
    public class GetNumbersQuery : IRequest<ContactInfo>
    {
        public int PersonId { get; }
        public GetNumbersQuery(int personId)
        {
            PersonId = personId;
        }

        public class GetNumbersQueryHandler : IRequestHandler<GetNumbersQuery, ContactInfo>
        {
            private readonly IPersonRepository _personRepository;
            private readonly IPhoneRepository _phoneRepository;
            private readonly IPhone2PersonRepository _phone2PersonRepository;
            public GetNumbersQueryHandler(IPersonRepository personRepository, IPhoneRepository phoneRepository, IPhone2PersonRepository phone2PersonRepository)
            {
                _personRepository = personRepository;
                _phoneRepository = phoneRepository;
                _phone2PersonRepository = phone2PersonRepository;
                
            }
            public async Task<ContactInfo> Handle(GetNumbersQuery request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.ReadAsync(request.PersonId);
                if (person == null)
                    throw new EntityNotFoundException();

                var phones2ThisPerson = (await _phone2PersonRepository.ReadAsync(x => x.PersonId == request.PersonId)).AsReadOnlyList();

                var phones = new List<SimplePhoneConnection>();
                foreach (var phone2ThisPerson in phones2ThisPerson)
                {
                    var phone = await _phoneRepository.ReadAsync(phone2ThisPerson.PhoneId);
                    phones.Add(new SimplePhoneConnection(phone, phone2ThisPerson.Id) );
                }

                var mobiles = phones.Where(x => x.Phone.Type == Model.Enums.PhoneType.Mobile).Select(x => new SimplePhone(x.Phone.Id, x.Phone.Number, x.ConnectionId)).AsReadOnlyList();
                var offices = phones.Where(x => x.Phone.Type == Model.Enums.PhoneType.Office).Select(x => new SimplePhone(x.Phone.Id, x.Phone.Number, x.ConnectionId)).AsReadOnlyList();
                var homes = phones.Where(x => x.Phone.Type == Model.Enums.PhoneType.Home).Select(x => new SimplePhone(x.Phone.Id, x.Phone.Number, x.ConnectionId)).AsReadOnlyList();

                var contactInfo = new ContactInfo(request.PersonId, $"{person.FirstName} {person.LastName}", offices, homes, mobiles);

                return contactInfo;
            }
        }
    }
}

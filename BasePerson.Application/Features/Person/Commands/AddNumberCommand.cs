using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using MediatR;

namespace BasePerson.Application.Features.Person.Commands
{
    public class AddNumberCommand : IRequest<int>
    {
        public int PhoneId { get; }
        public int PersonId { get; set; }
        public AddNumberCommand(int phoneId, int personId)
        {
            PhoneId = phoneId;
            PersonId = personId;
        }

        public class AddPhoneCommandHandler : IRequestHandler<AddNumberCommand, int>
        {
            private readonly IPersonRepository _personRepository;
            private readonly IPhoneRepository _phoneRepository;
            private readonly IPhone2PersonRepository _phone2PersonRepository;
            public AddPhoneCommandHandler(IPhone2PersonRepository phone2PersonRepository, IPhoneRepository phoneRepository, IPersonRepository personRepository)
            {
                _phone2PersonRepository = phone2PersonRepository;
                _phoneRepository = phoneRepository;
                _personRepository = personRepository;
            }
            public async Task<int> Handle(AddNumberCommand request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.ReadAsync(request.PersonId);
                if (person == null)
                    throw new EntityNotFoundException($"PersonId:{request.PersonId}");

                var phone = await _phoneRepository.ReadAsync(request.PhoneId);
                if (phone == null)
                    throw new EntityNotFoundException($"PhoneId:{request.PhoneId}");

                var anotherConsumerOfThisPhone = (await _phone2PersonRepository.ReadAsync(x => x.PhoneId == request.PhoneId && x.PersonId != request.PersonId)).SingleOrDefault();
                if (phone.Type == Model.Enums.PhoneType.Mobile && anotherConsumerOfThisPhone != null)
                    throw new InvalidOperationException($"This Mobile Number {phone.Number} belongs to Person:{anotherConsumerOfThisPhone.PersonId}");

                var existingPhone2Person = (await _phone2PersonRepository.ReadAsync(x => x.PersonId == request.PersonId && x.PhoneId == request.PhoneId)).SingleOrDefault();
                if (existingPhone2Person != null)
                    throw new InvalidOperationException($"this person ID:{request.PersonId} already has this number:{phone.Number} ID:{request.PhoneId}");

                var phone2Person = new Phone2Person() { CreatedOn = DateTime.Now, PersonId = request.PersonId, PhoneId = request.PhoneId};
                var generatedId = await _phone2PersonRepository.CreateAsync(phone2Person);
                return generatedId;
            }
        }
    }
}

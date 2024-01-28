using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.City.Commands
{
    public class DeleteCityCommand : IRequest<int>
    {
        public int Id { get; }
        public DeleteCityCommand(int id)
        {
            Id = id;
        }

        public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, int>
        {
            private readonly ICityRepository _cityRepository;
            public DeleteCityCommandHandler(ICityRepository cityRepository)
            {
                _cityRepository = cityRepository;
            }
            public async Task<int> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var city = await _cityRepository.ReadAsync(request.Id);
                if (city == null)
                    throw new EntityNotFoundException();
                return await _cityRepository.DeleteAsync(request.Id);
            }
        }
    }
}

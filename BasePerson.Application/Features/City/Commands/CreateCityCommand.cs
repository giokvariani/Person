using BasePerson.Application.DTOs.City;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.City.Commands
{
    public class CreateCityCommand : IRequest<int>
    {
        public CreateCityCommand(CityDto cityDto) => CityDto = cityDto;
        private CityDto CityDto { get; }
        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
        {
            private readonly ICityRepository _cityRepository;
            public CreateCityCommandHandler(ICityRepository cityRepository)
            {
                _cityRepository = cityRepository;
            }
            public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var name = request.CityDto.Name;
                var existingCity = (await _cityRepository.ReadAsync(x => x.Name == name)).SingleOrDefault();

                if (existingCity != null)
                    throw new InvalidOperationException($"City {name} already exists.");

                var city = new Model.BusinessObjects.City() { CreatedOn = DateTime.Now, Name = name };
                return await _cityRepository.CreateAsync(city);
            }
        }
    }
}

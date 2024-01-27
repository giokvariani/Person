using BasePerson.Application.DTOs.City;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.City.Commands
{
    public class UpdateCityCommand : IRequest<int>
    {
        public ExistingCityDto CityDto { get; }
        public UpdateCityCommand(ExistingCityDto cityDto)
        {            CityDto = cityDto;  
        }

        public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, int>
        {
            private readonly ICityRepository _cityRepository;
            public UpdateCityCommandHandler(ICityRepository cityRepository)
            {
                _cityRepository = cityRepository;
            }
            public async Task<int> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
            {
                var name = request.CityDto.Name;
                var sameCountry = (await _cityRepository.ReadAsync(x => x.Name == name && request.CityDto.Id != x.Id)).FirstOrDefault();

                if (sameCountry != null)
                    throw new InvalidOperationException($"City {name} already exists! ID:{sameCountry}");

                var city = new Model.BusinessObjects.City() { Name = request.CityDto.Name, Id = request.CityDto.Id , UpdatedOn = DateTime.Now };
                return await _cityRepository.UpdateAsync(request.CityDto.Id, city);
            }
        }
    }
}

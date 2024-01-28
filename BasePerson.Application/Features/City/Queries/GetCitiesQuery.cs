using BasePerson.Application.DTOs.City;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.City.Queries
{
    public class GetCitiesQuery : IRequest<List<ExistingCityDto>>
    {
        public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<ExistingCityDto>>
        {
            private readonly ICityRepository _cityRepository;
            public GetCitiesQueryHandler(ICityRepository cityRepository)
            {
                _cityRepository = cityRepository;
            }
            public async Task<List<ExistingCityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
            {
                var cities = await _cityRepository.ReadAsync();
                return cities.Select(x => new ExistingCityDto() { Id = x.Id, Name = x.Name}).ToList();
            }
        }
    }
}

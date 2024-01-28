using BasePerson.Application.DTOs.City;
using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using MediatR;

namespace BasePerson.Application.Features.City.Queries
{
    public class GetCityQuery : IRequest<ExistingCityDto>
    {
        public int Id { get; }
        public GetCityQuery(int id)
        {
            Id = id;
        }
        public class GetCityQueryHandler : IRequestHandler<GetCityQuery, ExistingCityDto>
        {
            private readonly ICityRepository _cityRepository;
            public GetCityQueryHandler(ICityRepository cityRepository)
            {
                _cityRepository = cityRepository;
            }
            public async Task<ExistingCityDto> Handle(GetCityQuery request, CancellationToken cancellationToken)
            {
                var city = await _cityRepository.ReadAsync(request.Id);
                if (city == null)
                    throw new EntityNotFoundException();
                var existingCityDto = new ExistingCityDto() { Id = city.Id, Name = city.Name };
                return existingCityDto;
            }
        }
    }
}

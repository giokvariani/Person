using BasePerson.Application.DTOs.City;
using BasePerson.Application.Features.City.Commands;
using BasePerson.Application.Features.City.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasePerson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var cityQuery = new GetCityQuery(id);
            var existingCity = await _mediator.Send(cityQuery);
            return Ok(existingCity);
        }

        [HttpGet]
        public async Task<ActionResult<List<ExistingCityDto>>> GetCities()
        {
            var cities = await _mediator.Send(new GetCitiesQuery());
            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> City(CityDto city)
        {
            var cityCommand = new CreateCityCommand(city);
            var cityId = await _mediator.Send(cityCommand);
            return Ok(cityId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var cityCommand = new DeleteCityCommand(id);
            var result = await _mediator.Send(cityCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(ExistingCityDto existingCityDto)
        {
            var updateCityCommand = new UpdateCityCommand(existingCityDto);
            var result = await _mediator.Send(updateCityCommand);
            return Ok(result);
        }
    }

}
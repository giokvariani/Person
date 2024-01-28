//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace BasePerson.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PersonController : ControllerBase
//    {
//        private readonly IMediator _mediator;
//        public PersonController(IMediator mediator) => _mediator = mediator;

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetCity(int id)
//        {
//            var cityQuery = new GetPersonQuery(id);
//            var existingCity = await _mediator.Send(cityQuery);
//            return Ok(existingCity);
//        }

//        [HttpPost]
//        public async Task<IActionResult> City(PersonDto city)
//        {
//            var cityCommand = new CreatePersonCommand(city);
//            var cityId = await _mediator.Send(cityCommand);
//            return Ok(cityId);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCity(int id)
//        {
//            var cityCommand = new DeletePersonCommand(id);
//            var result = await _mediator.Send(cityCommand);
//            return Ok(result);
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdateCity(ExistingCityDto existingCityDto)
//        {
//            var updateCityCommand = new UpdateCityCommand(existingCityDto);
//            var result = await _mediator.Send(updateCityCommand);
//            return Ok(result);
//        }
//    }
//}

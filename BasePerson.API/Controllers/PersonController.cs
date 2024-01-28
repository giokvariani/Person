using BasePerson.Application.DTOs.Person;
using BasePerson.Application.Features.Person;
using BasePerson.Application.Features.Person.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasePerson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var query = new GetPersonQuery { Id = id };
            var person = await _mediator.Send(query);
            return Ok(person);
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var query = new GetPeopleQuery();
            var people = await _mediator.Send(query);
            return Ok(people);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDto personDto)
        {
            var command = new CreatePersonCommand { PersonDto = personDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var command = new DeletePersonCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson([FromBody] ExistingPersonDto personDto)
        {
            var command = new UpdatePersonCommand { PersonDto = personDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}

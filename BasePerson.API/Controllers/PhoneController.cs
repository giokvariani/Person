using BasePerson.Application.DTOs.Phone;
using BasePerson.Application.Features.Phone.Commands;
using BasePerson.Application.Features.Phone.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasePerson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PhoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Phone(int id)
        //{
        //    var query = new GetPhoneQuery(id);
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

        [HttpGet("{number}")]
        public async Task<IActionResult> Phone(string number)
        {
            var query = new GetPhoneQuery(number);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Phones()
        {
            var query = new GetPhonesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var command = new DeletePersonCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Phone([FromBody] PhoneDto phoneDto)
        {
            var command = new CreatePhoneCommand(phoneDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Phone([FromBody] ExistingPhoneDto phoneDto)
        {
            var command = new UpdatePhoneCommand(phoneDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

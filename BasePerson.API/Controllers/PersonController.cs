﻿using BasePerson.Application.DTOs.Person;
using BasePerson.Application.Features.Person;
using BasePerson.Application.Features.Person.Commands;
using BasePerson.Application.Features.Person.Queries;
using BasePerson.Model.Enums;
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

        [HttpPost("ConnectPeople")]
        public async Task<IActionResult> ConnectPeople(ConnectedPeopleDto connectedPeople)
        {
            var command = new ConnectPeopleCommand(connectedPeople);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DisconnectPeople")]
        public async Task<IActionResult> DisconnectPeople(int id)
        {
            var command = new DisconnectPeopleCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("Networking")]
        public async Task<IActionResult> Networking(int id)
        {
            var query = new GetNetworkingQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
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


        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] ExistingPersonDto personDto)
        {
            var command = new UpdatePersonCommand { PersonDto = personDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}

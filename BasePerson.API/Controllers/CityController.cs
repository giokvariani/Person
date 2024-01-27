using BasePerson.Application.DTOs.City;
using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using Microsoft.AspNetCore.Mvc;

namespace BasePerson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMediator
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var city = await _cityRepository.ReadAsync(id);
            return city == null ? NotFound() : Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> City(City city)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var createdCity = await _cityRepository.CreateAsync(city);
            return Ok(createdCity);
        }

        // DELETE method to delete an existing city
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _cityRepository.ReadAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            await _cityRepository.DeleteAsync(id);
            return NoContent();
        }

        // PUT method to update an existing city
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCity(SetCityDto)
        //{
        //    if (id != cityModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _cityRepository.UpdateAsync(cityModel);
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
    }

}
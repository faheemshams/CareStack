using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        IService<CityDto,City> _cityService;

        public CityController(IService<CityDto, City> _cityService)
        {
            this._cityService = _cityService;   
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            try
            {
                return Ok(_cityService.GetAllItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpGet("{cityAbbrevation}")]
        public IActionResult GetCity(string cityAbbrevation)  
        {
            try
            {
                var result = _cityService.GetItem(cityAbbrevation);
                
                if(result == null)
                return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpPost]
        public IActionResult CreateCity(CityDto cityDto) 
        {
            try
            {
                if(cityDto == null)
                return BadRequest();

                if(_cityService.AddItem(cityDto) == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Duplicate abbreviation");

                return Ok();
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new City");
            }
        }

        [HttpPut]
        public IActionResult UpdateCity(CityDto newCity)
        {
            try
            {
                var result = _cityService.UpdateItem(newCity);

                if (result == null)
                {
                    return NotFound("City not found");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating City");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCity(string cityAbbreviation)
        {
            try
            {
                var result = _cityService.GetItem(cityAbbreviation);

                if (result == null)
                return NotFound("City not found");
                else
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the City");
            }
        }
    }
}



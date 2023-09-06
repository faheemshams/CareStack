using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        IService<City> _cityService;

        public CityController(IService<City> _cityService)
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

        [HttpGet("{id:int}")]
        public IActionResult GetCity(int id)  
        {
            try
            {
                var result = _cityService.GetItemById(id);
                
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
        public IActionResult CreateCity(City city) 
        {
            try
            {
                if(city == null)
                return BadRequest();

                if(_cityService.AddItem(city) == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Duplicate abbreviation");

                return Ok();
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new City");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCity(int id, City newCity)
        {
            if(id != newCity.CityId) 
            return BadRequest();   
            
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
        public IActionResult DeleteCity(int id)
        {
            try
            {
                var result = _cityService.DeleteItem(id);

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



using BuisnessLayer.Exceptions;
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
        IService<CityDto> _cityService;

        public CityController(IService<CityDto> _cityService)
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
                return Ok(result);
            }
            catch(ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpPost]
        public IActionResult CreateCity(CityDto cityDto) 
        {
            if (cityDto == null)
                return BadRequest();
            try
            {
                _cityService.AddItem(cityDto);
                return Ok("city added successfully");
            }
            catch (ExceptionWhileAdding ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new City");
            }
        }

        [HttpPut]
        public IActionResult UpdateCity(CityDto newCity)
        {
            if(newCity == null)
                return BadRequest();
            try
            {
                _cityService.UpdateItem(newCity);
                 return Ok("city updated successfully");
            }
            catch (ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
            }
            catch (ExceptionWhileUpdating ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating City");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCity(string cityAbbreviation)
        {
           return BadRequest(); 
        }
    }
}



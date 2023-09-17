using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    { 
        IService<FacilityDto, Facility> _facilityService;
        public FacilityController(IService<FacilityDto, Facility> _facilityService)
        {
            this._facilityService = _facilityService;
        }
         
        [HttpGet]
        public IActionResult GetFacilities()
        {
            try
            {
                return Ok(_facilityService.GetAllItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFacility(int id)
        {
            try
            {
                var result = _facilityService.GetItemById(id);

                if (result == null)
                return NotFound();

                return Ok(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpPost]
        public IActionResult CreateFacility(FacilityDto facilityDto)
        {   
            try
            {
                if(facilityDto == null)
                return BadRequest();

                if (_facilityService.AddItem(facilityDto) == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Cannot add facility");

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Facility");
            }
        }

        [HttpPut]
        public IActionResult UpdateFacility(FacilityDto facilityDto)
        {
            if(facilityDto == null)
            return BadRequest();
            try
            {
                var result = _facilityService.UpdateItem(facilityDto);

                if (result == null)
                {
                    return NotFound("Facility not found");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Facility");
            }
        }

        [HttpDelete]
        public IActionResult DeleteFacility(string FacilityName)
        {
            try
            {
                var result = _facilityService.DeleteItem(FacilityName);

                if (result == null)
                return NotFound("facility not found");
                else
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the facility");
            }
        }
    }
}



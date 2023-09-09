using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    { 
        IService<Facility> _facilityService;
        public FacilityController(IService<Facility> _facilityService)
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

        [HttpGet("{id:int}")]
        public IActionResult GetFacility(int id)
        {
            try
            {
                var result = _facilityService.GetItemById(id);

                if (result == null)
                return NotFound();

                return Ok(result);
            }
            catch (Exception)
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

                Facility facility = new Facility()
                {
                    FacilityName = facilityDto.FacilityName,
                    CityId = facilityDto.CityId,
                    BuildingId = facilityDto.BuildingId,    
                    Floor = facilityDto.Floor
                };

                if (_facilityService.AddItem(facility) == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Cannot add facility");

                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Facility");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateFacility(int id, FacilityDto facilityDto)
        {
            if(facilityDto == null)
            return BadRequest();
            
            Facility facility = new Facility()
            {
                FacilityId = id,
                FacilityName = facilityDto.FacilityName,
                CityId = facilityDto.CityId,
                BuildingId = facilityDto.BuildingId,
                Floor  = facilityDto.Floor, 
            };
            
            try
            {
                var checkId = _facilityService.GetItemById(id);
                if (checkId == null)
                return NotFound("Item doesn't exist");
                
                var result = _facilityService.UpdateItem(facility);

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
        public IActionResult DeleteFacility(int id)
        {
            try
            {
                var result = _facilityService.DeleteItem(id);

                if (result == null)
                return NotFound("facility not found");

                _facilityService.DeleteItem(id);
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the facility");
            }
        }
    }
}



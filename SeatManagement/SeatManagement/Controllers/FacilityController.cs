using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    { 
        IService<FacilityDto> _facilityService;
        public FacilityController(IService<FacilityDto> _facilityService)
        {
            this._facilityService = _facilityService;
        }
         
        [HttpGet]
        [Authorize]
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
                return Ok(result);
            }
            catch(ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpPost]
        public IActionResult CreateFacility(FacilityDto facilityDto)
        {
            if (facilityDto == null)
                return BadRequest();
            try
            {
                _facilityService.AddItem(facilityDto);
                return Ok("facility added successfully");
            }
            catch (ExceptionWhileAdding ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdateFacility(FacilityDto facilityDto)
        {
            if(facilityDto == null)
            return BadRequest();
            try
            {
                _facilityService.UpdateItem(facilityDto);
                return Ok("facility updated successfully");
            }
            catch (ExceptionWhileUpdating ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Facility");
            }
        }

        [HttpDelete]
        public IActionResult DeleteFacility(string FacilityName)
        {
            return BadRequest();
        }
    }
}



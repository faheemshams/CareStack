using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        IService<BuildingDto, Building> _buildingService;

        public BuildingController(IService<BuildingDto, Building> _buildingService) 
        {
            this._buildingService = _buildingService;
        }

        [HttpGet]
        public IActionResult GetBuildings()
        {
            try
            {
                return Ok(_buildingService.GetAllItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpGet("{BuildingAbbrevation}")]
        public IActionResult GetBuilding(string BuildingAbbrevation)
        {
            try
            {
                var result = _buildingService.GetItem(BuildingAbbrevation);

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
        public IActionResult CreateBuilding(BuildingDto buildingDto)
        {
            try
            {
                if (buildingDto == null)
                return BadRequest();

                if (_buildingService.AddItem(buildingDto) == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Duplicate abbreviation");

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Building");
            }
        }

        [HttpPut]
        public IActionResult UpdateBuilding(BuildingDto newBuilding)
        {
            try
            {
                var result = _buildingService.UpdateItem(newBuilding);

                if (result == null)
                {
                    return NotFound("Building not found");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Building");
            }
        }

        [HttpDelete]
        public IActionResult DeleteBuilding(string buildingAbbreviation)
        {
            try
            {
                var result = _buildingService.DeleteItem(buildingAbbreviation);

                if (result == null)
                    return NotFound("Building not found");
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



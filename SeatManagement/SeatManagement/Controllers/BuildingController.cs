using BuisnessLayer.Exceptions;
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
        IService<BuildingDto> _buildingService;

        public BuildingController(IService<BuildingDto> _buildingService) 
        {
            this._buildingService = _buildingService;
        }

        [HttpGet]
        public IActionResult GetBuildings()
        {
            try
            {
                var buildings = _buildingService.GetAllItems();
                return Ok(buildings);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBuilding(int id)
        {
            try
            {
                var building = _buildingService.GetItemById(id);
                return Ok(building);
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
        public IActionResult CreateBuilding(BuildingDto buildingDto)
        {
            try
            {
                if (buildingDto == null)
                    return BadRequest();

                _buildingService.AddItem(buildingDto);   
                return Ok("Building added successfully");
            }
            catch (ExceptionWhileAdding ex)
            {
                return Conflict(ex.Message);
            }
            catch(Exception) 
            {
                return StatusCode(500, "An error occurred while adding Building");
            }
        }

        [HttpPut]
        public IActionResult UpdateBuilding(BuildingDto newBuilding)
        {
            if(newBuilding == null)
                return BadRequest();
            
            try
            {
                _buildingService.UpdateItem(newBuilding);
                 return Ok("Building updated successfully");
            }
            catch(ExceptionWhileUpdating ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Building");
            }
        }

        [HttpDelete]
        public IActionResult DeleteBuilding(string buildingAbbreviation)
        {
            return BadRequest();
        }
    }
}



using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        IService<Building> _buildingService;

        public BuildingController(IService<Building> _buildingService) 
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

        [HttpGet("{id:int}")]
        public IActionResult GetBuilding(int id)
        {
            try
            {
                var result = _buildingService.GetItemById(id);

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
        public IActionResult CreateBuilding(Building building)
        {
            try
            {
                if (building == null)
                return BadRequest();

                if (_buildingService.AddItem(building) == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Duplicate abbreviation");

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Building");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBuilding(int id, Building newBuilding)
        {
            if (id != newBuilding.BuildingId)
                return BadRequest();

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
        public IActionResult DeleteBuilding(int id)
        {
            try
            {
                var result = _buildingService.DeleteItem(id);

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



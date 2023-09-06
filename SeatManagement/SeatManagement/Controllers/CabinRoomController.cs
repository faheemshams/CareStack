using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Dto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinRoomController : ControllerBase
    {
        IService<CabinRoom> _cabinRoomService;
        public CabinRoomController(IService<CabinRoom> _cabinRoomService)
        {
            this._cabinRoomService = _cabinRoomService;
        }

        [HttpGet]
        public IActionResult GetOpenRooms()
        {
            try
            {
                return Ok(_cabinRoomService.GetAllItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCabinRoom(int id)
        {
            try
            {
                var result = _cabinRoomService.GetItemById(id);

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
        public IActionResult CreateCabinRoom(CreateCabinRoomDto cabinRoomDto)
        {
            try
            {
                if (cabinRoomDto == null)
                    return BadRequest();

                CabinRoom cabinRoom = new CabinRoom()
                {
                    CabinName = cabinRoomDto.CabinName,
                    FacilityId = cabinRoomDto.FacilityId,
                };

                if (_cabinRoomService.AddItem(cabinRoom) == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Cannot create a CabinRoom");

                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new CabinRoom");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCabinRoom(int id, UpdateCabinRoomDto cabinRoomDto)
        {
            if (cabinRoomDto == null)
            return BadRequest();

            CabinRoom cabinRoom = new CabinRoom()
            {
                CabinId = id,
                CabinName = cabinRoomDto.CabinName,
                FacilityId = cabinRoomDto.FacilityId,
                EmployeeId = cabinRoomDto.EmployeeId,
            };

            try
            {
                var checkId = _cabinRoomService.GetItemById(id);
                if (checkId == null)
                return NotFound("Item doesn't exist");

                var result = _cabinRoomService.UpdateItem(cabinRoom);

                if (result == null)
                {
                    return NotFound("Cabinroom doesn't exist");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Cabinroom");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCabinRoom(int id)
        {
            try
            {
                var result = _cabinRoomService.DeleteItem(id);

                if (result == null)
                return NotFound("Cabinroom not found");

                _cabinRoomService.DeleteItem(id);
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the Cabinroom");
            }
        }
    }
}



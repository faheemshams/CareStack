using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenRoomController : ControllerBase
    {
        IService<OpenRoom> _openRoomService;
        public OpenRoomController(IService<OpenRoom> _openRoomService)
        {
            this._openRoomService = _openRoomService;
        }

        [HttpGet]
        public IActionResult GetOpenRooms()
        {
            try
            {
                return Ok(_openRoomService.GetAllItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOpenRoom(int id)
        {
            try
            {
                var result = _openRoomService.GetItemById(id);

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
        public IActionResult CreateOpenRoom(OpenRoomDto openRoomDto)
        {
            try
            {
                if (openRoomDto == null)
                    return BadRequest();

                OpenRoom openRoom = new OpenRoom()
                {
                    OpenRoomName = openRoomDto.OpenRoomName,
                    SeatCount = openRoomDto.SeatCount,
                    FacilityId = openRoomDto.FacilityId,
                };

                if (_openRoomService.AddItem(openRoom) == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Cannot create an OpenRoom");
                 
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex + " Error creating new Openroom");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOpenRoom(int id, OpenRoomDto openRoomDto)
        {
            if (openRoomDto == null)
            return BadRequest();

            OpenRoom openRoom = new OpenRoom()
            {
                OpenRoomId = id,
                OpenRoomName = openRoomDto.OpenRoomName,
                SeatCount = openRoomDto.SeatCount,
                FacilityId = openRoomDto.FacilityId,
            };

            try
            {
                var checkId = _openRoomService.GetItemById(id);
                if (checkId == null)
                return NotFound("Item doesn't exist");

                var result = _openRoomService.UpdateItem(openRoom);

                if (result == null)
                {
                    return NotFound("Openroom doesn't exist");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating OpenRoom");
            }
        }

        [HttpDelete]
        public IActionResult DeleteOpenRoom(int id)
        {
            try
            {
                var result = _openRoomService.DeleteItem(id);

                if (result == null)
                return NotFound("openroom not found");

                _openRoomService.DeleteItem(id);
                return Ok("Deleted successfully");
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Ex + "Error deleting the openrrom");
            }
        }
    }
}



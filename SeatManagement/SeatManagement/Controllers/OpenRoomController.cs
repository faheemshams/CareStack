using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenRoomController : ControllerBase
    {
        IService<OpenRoomDto, OpenRoom> _openRoomService;
        public OpenRoomController(IService<OpenRoomDto, OpenRoom> _openRoomService)
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
        public IActionResult GetOpenRoom(string openRoomId)
        {
            try
            {
                var result = _openRoomService.GetItem(openRoomId);

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

                if (_openRoomService.AddItem(openRoomDto) == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Cannot create an OpenRoom");
                 
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex + "Error creating new Openroom");
            }
        }

        [HttpPut]
        public IActionResult UpdateOpenRoom(OpenRoomDto openRoomDto)
        {
            if (openRoomDto == null)
            return BadRequest();

            try
            {
                var result = _openRoomService.UpdateItem(openRoomDto);

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
        public IActionResult DeleteOpenRoom(string openRoomId)
        {
            try
            {
                var result = _openRoomService.DeleteItem(openRoomId);

                if (result == null)
                return NotFound("openroom not found");
                else
                return Ok("Deleted successfully");
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Ex + "Error deleting the openrrom");
            }
        }
    }
}



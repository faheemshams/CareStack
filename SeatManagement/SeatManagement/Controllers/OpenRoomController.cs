using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenRoomController : ControllerBase
    {
        IService<OpenRoomDto> _openRoomService;
        public OpenRoomController(IService<OpenRoomDto> _openRoomService)
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
                return Ok(result);
            }
            catch (ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpPost]
        public IActionResult CreateOpenRoom(OpenRoomDto openRoomDto)
        {
            if (openRoomDto == null)
                return BadRequest();
            try
            {
                _openRoomService.AddItem(openRoomDto);
                return Ok("open room added successfully");
            }
            catch (ExceptionWhileAdding ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Openroom");
            }
        }

        [HttpPut]
        public IActionResult UpdateOpenRoom(OpenRoomDto openRoomDto)
        {
            if (openRoomDto == null)
            return BadRequest();

            try
            {
                _openRoomService.UpdateItem(openRoomDto);
                return Ok("Seat count increased successfully");
            }
            catch (ExceptionWhileUpdating ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating OpenRoom");
            }
        }
    }
}



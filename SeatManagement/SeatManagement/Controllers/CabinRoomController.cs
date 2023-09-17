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
    public class CabinRoomController : ControllerBase
    {
        IService<CabinRoomDto> _cabinRoomService;
        public CabinRoomController(IService<CabinRoomDto> _cabinRoomService)
        {
            this._cabinRoomService = _cabinRoomService;
        }

        [HttpGet]
        public IActionResult GetCabinRooms()
        {
            try
            {
                var cabinrooms = (_cabinRoomService.GetAllItems());
                return Ok(cabinrooms);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving cabin rooms");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCabinRoom(int id)
        {
            try
            {
                var result = _cabinRoomService.GetItemById(id);
                return Ok(result);
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
        public IActionResult CreateCabinRoom(CabinRoomDto cabinRoomDto)
        {
            if (cabinRoomDto == null)
                return BadRequest();
            try
            {
                _cabinRoomService.AddItem(cabinRoomDto);
                return Ok("cabin created successfully");
            }
            catch(ExceptionWhileAdding ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new CabinRoom");
            }
        }

        [HttpPut]
        public IActionResult UpdateCabinRoom(CabinRoomDto cabinRoomDto)
        {
            if (cabinRoomDto == null)
            return BadRequest();

            try
            {
                _cabinRoomService.UpdateItem(cabinRoomDto);
                return Ok("cabin room updated successfully");
            }
            catch(ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
            }
            catch (ExceptionWhileUpdating ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Cabinroom");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCabinRoom(string CabinNumber)
        {
            return BadRequest();
        }
    }
}



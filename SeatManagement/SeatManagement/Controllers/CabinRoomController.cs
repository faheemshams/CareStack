using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinRoomController : ControllerBase
    {
        IService<CabinRoomDto, CabinRoom> _cabinRoomService;
        public CabinRoomController(IService<CabinRoomDto, CabinRoom> _cabinRoomService)
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

        [HttpGet("{id:string}")]
        public IActionResult GetCabinRoom(string CabinNumber)
        {
            try
            {
                var result = _cabinRoomService.GetItem(CabinNumber);

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
        public IActionResult CreateCabinRoom(CabinRoomDto cabinRoomDto)
        {
            try
            {
                if (cabinRoomDto == null)
                return BadRequest();

                if (_cabinRoomService.AddItem(cabinRoomDto) == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Cannot create a CabinRoom");

                return Ok();

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
                var result = _cabinRoomService.UpdateItem(cabinRoomDto);

                if (result == null)
                return NotFound("Cabinroom doesn't exist");
                
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Cabinroom");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCabinRoom(string CabinNumber)
        {
            try
            {
                var result = _cabinRoomService.DeleteItem(CabinNumber);

                if (result == null)
                return NotFound("Cabinroom not found");
                else
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the Cabinroom");
            }
        }
    }
}



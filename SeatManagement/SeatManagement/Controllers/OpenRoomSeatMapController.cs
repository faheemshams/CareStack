using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenRoomSeatMapController : ControllerBase
    {
        private readonly IService<OpenRoomSeatAllocationDto,OpenRoomSeatAllocation> _openSeatAllocation;

        public OpenRoomSeatMapController(IService<OpenRoomSeatAllocationDto, OpenRoomSeatAllocation> _openSeatAllocation)
        {
            this._openSeatAllocation = _openSeatAllocation;
        }

        [HttpGet]
        public IActionResult GetAllAllocatedSeats()
        {
            try
            {
                var openRoomSeats = _openSeatAllocation.GetAllItems();
                return Ok(openRoomSeats);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex +  "Error while retrieving Open Room Seats");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAllocatedSeat(string id)
        {
            try
            {
                var openRoomSeat = _openSeatAllocation.GetItem(id);

                if (openRoomSeat == null)
                return NotFound();

                return Ok(openRoomSeat);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while retrieving open room seat");
            }
        }

        [HttpPut]
        public IActionResult UpdateOpenRoomSeatMap(OpenRoomSeatAllocationDto openRoomSeatMapDto)
        {
            if (openRoomSeatMapDto == null)
            return BadRequest();

            try
            {
                var updatedSeat = _openSeatAllocation.UpdateItem(openRoomSeatMapDto);

                if (updatedSeat == null)
                return NotFound("Could not update seat details");

                return Ok(updatedSeat);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error updating OpenRoomSeatMap");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOpenRoomSeatMap(string id)
        {
            try
            {
                var deleteSeatAllocation = _openSeatAllocation.DeleteItem(id);

                if (deleteSeatAllocation == null)
                    return NotFound("No allocated seat found");

                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error deleting Allocated seat");
            }
        }
    }
}

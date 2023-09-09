using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenRoomSeatMapController : ControllerBase
    {
        private readonly IService<OpenRoomSeatAllocation> _employeeAllocation;

        public OpenRoomSeatMapController(IService<OpenRoomSeatAllocation> _employeeAllocation)
        {
            this._employeeAllocation = _employeeAllocation;
        }

        [HttpGet]
        public IActionResult GetAllAllocatedSeats()
        {
            try
            {
                var openRoomSeats = _employeeAllocation.GetAllItems();
                return Ok(openRoomSeats);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex +  "Error while retrieving Open Room Seats");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAllocatedSeat(int id)
        {
            try
            {
                var openRoomSeat = _employeeAllocation.GetItemById(id);

                if (openRoomSeat == null)
                return NotFound();

                return Ok(openRoomSeat);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while retrieving open room seat");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOpenRoomSeatMap(int id, OpenRoomSeatAllocationDto openRoomSeatMapDto)
        {
            if (openRoomSeatMapDto == null)
            return BadRequest();

            try
            {
                var existingAllocatedSeat = _employeeAllocation.GetItemById(id);

                if (existingAllocatedSeat == null)
                return NotFound("Seat doesn't exist");

                existingAllocatedSeat.SeatNumber = openRoomSeatMapDto.SeatNumber;
                existingAllocatedSeat.OpenRoomId = openRoomSeatMapDto.OpenRoomId;
                existingAllocatedSeat.EmployeeId = openRoomSeatMapDto.EmployeeId;

                var updatedSeat = _employeeAllocation.UpdateItem(existingAllocatedSeat);

                if (updatedSeat == null)
                return NotFound("Could not update seat details");

                return Ok(updatedSeat);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error updating OpenRoomSeatMap");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOpenRoomSeatMap(int id)
        {
            try
            {
                var deleteSeatAllocation = _employeeAllocation.DeleteItem(id);

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

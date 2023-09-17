using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenRoomSeatMapController : ControllerBase
    {
        private readonly IService<OpenRoomSeatAllocationDto> _openSeatAllocation;

        public OpenRoomSeatMapController(IService<OpenRoomSeatAllocationDto> _openSeatAllocation)
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
                return StatusCode(500,"Error while retrieving Open Room Seats");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAllocatedSeat(int id)
        {
            try
            {
                var openRoomSeat = _openSeatAllocation.GetItemById(id);
                return Ok(openRoomSeat);
            }
            catch (ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
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
                _openSeatAllocation.UpdateItem(openRoomSeatMapDto);
                return Ok("employee successfully allocated");
            }
            catch (ExceptionWhileUpdating ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error updating OpenRoomSeatMap");
            }
        }
    }
}

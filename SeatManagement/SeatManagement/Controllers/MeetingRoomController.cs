using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IService<MeetingRoomDto> _meetingRoomService;

        public MeetingRoomController(IService<MeetingRoomDto> meetingRoomService)
        {
            this._meetingRoomService = meetingRoomService;
        }

        [HttpGet]
        public IActionResult GetMeetingRooms()
        {
            try
            {
                var meetingRooms = _meetingRoomService.GetAllItems();
                return Ok(meetingRooms);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving meeting rooms");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMeetingRoom(int id)
        {
            try
            {
                var meetingRoom = _meetingRoomService.GetItemById(id);
                return Ok(meetingRoom);
            }
            catch (ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving meeting room");
            }
        }

        [HttpPost]
        public IActionResult CreateMeetingRoom(MeetingRoomDto meetingRoomDto)
        {

            if (meetingRoomDto == null)
                return BadRequest();
            try
            {
                _meetingRoomService.AddItem(meetingRoomDto);
                return Ok("meeting room added successfully");
            }
            catch (ExceptionWhileAdding ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding new meeting room");
            }
        }

        [HttpPut]
        public IActionResult UpdateMeetingRoom(MeetingRoomDto meetingRoomDto)
        {
            if (meetingRoomDto == null)
            return BadRequest();

            try
            {
                _meetingRoomService.UpdateItem(meetingRoomDto);
                return Ok("meeting room updated successfully");
            }
            catch (ExceptionWhileUpdating ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating meeting room");
            }
        }

        [HttpDelete]
        public IActionResult DeleteMeetingRoom(string MeetingRoomName)
        {
           return BadRequest(); 
        }
    }
}

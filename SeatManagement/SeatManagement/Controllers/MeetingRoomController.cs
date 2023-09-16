using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IService<MeetingRoomDto, MeetingRoom> _meetingRoomService;

        public MeetingRoomController(IService<MeetingRoomDto, MeetingRoom> meetingRoomService)
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

        [HttpGet("{MeetingRoomName}")]
        public IActionResult GetMeetingRoom(string MeetingRoomName)
        {
            try
            {
                var meetingRoom = _meetingRoomService.GetItem(MeetingRoomName);

                if (meetingRoom == null)
                return NotFound();

                return Ok(meetingRoom);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving meeting room");
            }
        }

        [HttpPost]
        public IActionResult CreateMeetingRoom(MeetingRoomDto meetingRoomDto)
        {
            try
            {
                if (meetingRoomDto == null)
                return BadRequest();

                var createdMeetingRoom = _meetingRoomService.AddItem(meetingRoomDto);

                if (createdMeetingRoom == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Cannot add meeting room");

                return Ok(createdMeetingRoom);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new meeting room");
            }
        }

        [HttpPut]
        public IActionResult UpdateMeetingRoom(MeetingRoomDto meetingRoomDto)
        {
            if (meetingRoomDto == null)
            return BadRequest();

            try
            {
                var updatedMeetingRoom = _meetingRoomService.UpdateItem(meetingRoomDto);

                if (updatedMeetingRoom == null)
                return NotFound("Meeting room not found");

                return Ok(updatedMeetingRoom);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating meeting room");
            }
        }

        [HttpDelete]
        public IActionResult DeleteMeetingRoom(string MeetingRoomName)
        {
            try
            {
                var deletedMeetingRoom = _meetingRoomService.DeleteItem(MeetingRoomName);

                if (deletedMeetingRoom == null)
                return NotFound("Meeting room not found");

                return Ok("Meeting room deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the meeting room");
            }
        }
    }
}

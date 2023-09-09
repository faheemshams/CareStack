using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;

using Microsoft.AspNetCore.Mvc;
using System;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IService<MeetingRoom> _meetingRoomService;

        public MeetingRoomController(IService<MeetingRoom> meetingRoomService)
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

                MeetingRoom meetingRoom = new MeetingRoom()
                {
                    MeetingRoomName = meetingRoomDto.MeetingRoomNumber,
                    SeatCount = meetingRoomDto.SeatCount,
                    FacilityId = meetingRoomDto.FacilityId,
                };

                var createdMeetingRoom = _meetingRoomService.AddItem(meetingRoom);

                if (createdMeetingRoom == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Cannot add meeting room");

                return Ok(createdMeetingRoom);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new meeting room");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateMeetingRoom(int id, MeetingRoomDto meetingRoomDto)
        {
            if (meetingRoomDto == null)
                return BadRequest();


            MeetingRoom meetingRoom = new MeetingRoom()
            {
                MeetingRoomId = id,
                MeetingRoomName = meetingRoomDto.MeetingRoomNumber,
                SeatCount = meetingRoomDto.SeatCount,
                FacilityId = meetingRoomDto.FacilityId,
            };

            try
            {
                var checkId = _meetingRoomService.GetItemById(id);
                if (checkId == null)
                    return NotFound("Meeting room doesn't exist");

                var updatedMeetingRoom = _meetingRoomService.UpdateItem(meetingRoom);

                if (updatedMeetingRoom == null)
                    return NotFound("Meeting room not found");

                return Ok(updatedMeetingRoom);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating meeting room");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteMeetingRoom(int id)
        {
            try
            {
                var deletedMeetingRoom = _meetingRoomService.DeleteItem(id);

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

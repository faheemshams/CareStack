using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;

namespace BuisnessLayer.Services
{
    public class MeetingRoomService<T> : IService<MeetingRoom>
    {
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;

        public MeetingRoomService(IRepository<MeetingRoom> meetingRoomRepository)
        {
            _meetingRoomRepository = meetingRoomRepository;
        }

        public MeetingRoom[] GetAllItems()
        {
            return _meetingRoomRepository.GetAllItems().ToArray();
        }

        public MeetingRoom GetItemById(int id)
        {
            return _meetingRoomRepository.GetItemById(id);
        }

        public MeetingRoom AddItem(MeetingRoom meetingRoom)
        {
            _meetingRoomRepository.AddItem(meetingRoom);
            return meetingRoom;
        }

        public MeetingRoom DeleteItem(int id)
        {
            var meetingRoom = _meetingRoomRepository.GetItemById(id);

            if (meetingRoom == null)
                return null;

            _meetingRoomRepository.DeleteItem(id);
            return meetingRoom;
        }

        public MeetingRoom UpdateItem(MeetingRoom newMeetingRoom)
        {
            var existingMeetingRoom = _meetingRoomRepository.GetItemById(newMeetingRoom.MeetingRoomId);

            if (existingMeetingRoom == null)
            {
                return null;
            }

            existingMeetingRoom.MeetingRoomName = newMeetingRoom.MeetingRoomName;
            existingMeetingRoom.FacilityId = newMeetingRoom.FacilityId;
            existingMeetingRoom.SeatCount = newMeetingRoom.SeatCount;

            _meetingRoomRepository.UpdateItem(existingMeetingRoom);
            return existingMeetingRoom;
        }
    }
}

using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace BuisnessLayer.Services
{
    public class MeetingRoomService<Tin, Tout> : IService<MeetingRoomDto, MeetingRoom>
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

        public MeetingRoom GetItem(string MeetingRoomNumber)
        {
            return _meetingRoomRepository.GetAllItems().FirstOrDefault(x => x.MeetingRoomNumber ==  MeetingRoomNumber);
        }

        public MeetingRoom AddItem(MeetingRoomDto meetingRoom)
        {
            int meetingRoomCount = _meetingRoomRepository.GetAllItems().Where(x => x.FacilityId == meetingRoom.FacilityId).ToArray().Length;

            MeetingRoom newMeetingRoom = new MeetingRoom()
            {
                MeetingRoomNumber = string.Format(" M{0:D3}", meetingRoomCount + 1),
                SeatCount = meetingRoom.SeatCount,
                FacilityId = meetingRoom.FacilityId,
            };

            _meetingRoomRepository.AddItem(newMeetingRoom);
            return newMeetingRoom;
        }

        public MeetingRoom DeleteItem(string id)
        {
            /*
            var meetingRoom = _meetingRoomRepository.GetItemById(id);

            if (meetingRoom == null)
                return null;

            _meetingRoomRepository.DeleteItem(id);
            return meetingRoom;*/
            return null;
        }

        public MeetingRoom UpdateItem(MeetingRoomDto meetingRoomDto)
        {
            var meetingRoom = _meetingRoomRepository.GetAllItems().FirstOrDefault(x => x.MeetingRoomNumber == meetingRoomDto.MeetingRoomNumber);

            if (meetingRoom == null)
            return null;

            //meetingRoom.FacilityId = meetingRoomDto.FacilityId;
            meetingRoom.SeatCount = meetingRoomDto.SeatCount;

            _meetingRoomRepository.UpdateItem(meetingRoom);
            return meetingRoom;
        }
    }
}

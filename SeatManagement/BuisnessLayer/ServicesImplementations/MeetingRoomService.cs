using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace BuisnessLayer.Services
{
    public class MeetingRoomService<T> : IService<MeetingRoomDto>
    {
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public MeetingRoomService(IRepository<MeetingRoom> meetingRoomRepository, IRepository<Facility> facilityRepository)
        {
            _meetingRoomRepository = meetingRoomRepository;
            _facilityRepository = facilityRepository;
        }
        public MeetingRoomDto[] GetAllItems()
        {
            MeetingRoom[] meetingRooms =  _meetingRoomRepository.GetAllItems().ToArray();
            MeetingRoomDto[] meetingRoomDtos = new MeetingRoomDto[meetingRooms.Length];

            for(int i = 0; i < meetingRooms.Length; i++)
            {
                meetingRoomDtos[i] = ConvertMeetingToMeetingDto(meetingRooms[i]);
            }
            return meetingRoomDtos;
        }

        public MeetingRoomDto GetItemById(int MeetingRoomId)
        {
            var meetingRoom = _meetingRoomRepository.GetItemById(MeetingRoomId);
            if (meetingRoom == null)
                throw new ExceptionWhileFetching("Meeting room not found");
            else
                return ConvertMeetingToMeetingDto(meetingRoom);
        }

        public void AddItem(MeetingRoomDto meetingRoom)
        {
            if (_facilityRepository.GetItemById(meetingRoom.FacilityId) == null)
                throw new ExceptionWhileAdding("Facility not found");
            
            int meetingRoomCount = _meetingRoomRepository.GetAllItems().Where(x => x.FacilityId == meetingRoom.FacilityId).ToArray().Length;

            MeetingRoom newMeetingRoom = new MeetingRoom()
            {
                MeetingRoomNumber = string.Format(" M{0:D3}", meetingRoomCount + 1),
                SeatCount = meetingRoom.SeatCount,
                FacilityId = meetingRoom.FacilityId,
            };

            _meetingRoomRepository.AddItem(newMeetingRoom);
        }

        public void UpdateItem(MeetingRoomDto meetingRoomDto)
        {
            var meetingRoom = _meetingRoomRepository.GetAllItems().FirstOrDefault(x => x.MeetingRoomId == meetingRoomDto.MeetingRoomId);

            if (meetingRoom == null)
                throw new ExceptionWhileUpdating("Meeting room doesn't exist");

            meetingRoom.SeatCount = meetingRoomDto.SeatCount;

            _meetingRoomRepository.UpdateItem(meetingRoom);
        }
        private MeetingRoomDto ConvertMeetingToMeetingDto(MeetingRoom meetingRoom)
        {
            return new MeetingRoomDto()
            {
               MeetingRoomId = meetingRoom.MeetingRoomId,   
               MeetingRoomNumber=meetingRoom.MeetingRoomNumber, 
               SeatCount=meetingRoom.SeatCount, 
               FacilityId=meetingRoom.FacilityId,
            };
        }
        public void DeleteItem(string id)
        {
            /*
            var meetingRoom = _meetingRoomRepository.GetItemById(id);

            if (meetingRoom == null)
                return null;

            _meetingRoomRepository.DeleteItem(id);
            return meetingRoom;*/
        }
    }
}

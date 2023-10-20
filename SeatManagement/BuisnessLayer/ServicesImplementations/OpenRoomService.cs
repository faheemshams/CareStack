using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace BuisnessLayer.Services
{
    public class OpenRoomService<T> : IService<OpenRoomDto>
    {
        private readonly IRepository<OpenRoom> _openRoomRepository;
        private readonly IRepository<OpenRoomSeatAllocation> _openRoomSeatMapRepository;
        private readonly IRepository<Facility> _facilityRepository;
         
        public OpenRoomService(IRepository<OpenRoom> _repository,IRepository<OpenRoomSeatAllocation> _seatRepository, IRepository<Facility> _facilityRepository)
        {
            this._openRoomRepository = _repository;
            this._openRoomSeatMapRepository = _seatRepository;
            this._facilityRepository = _facilityRepository;
        }
        public OpenRoomDto[] GetAllItems()
        {
            OpenRoom[] openRooms =  _openRoomRepository.GetAllItems().ToArray();
            OpenRoomDto[] openRoomDtos = new OpenRoomDto[openRooms.Length];

            for(int  i = 0; i < openRooms.Length; i++)
                openRoomDtos[i] = ConvertEntityToDto(openRooms[i]);
            return openRoomDtos;    
        }

        public OpenRoomDto GetItemById(int openRoomId)
        {
            var openRoom = _openRoomRepository.GetItemById(openRoomId);
            if (openRoom == null)
                throw new ExceptionWhileFetching("Open room not found");
            else
                return ConvertEntityToDto(openRoom);
        }

        public void AddItem(OpenRoomDto openRoomDto)
        {
            if (_facilityRepository.GetItemById(openRoomDto.FacilityId) == null)
                throw new ExceptionWhileAdding("Facility doesn't exist");
            
            if (_openRoomRepository.GetAllItems().FirstOrDefault(x => x.FacilityId == openRoomDto.FacilityId) != null)
                throw new ExceptionWhileAdding("Already an open room exist for this facility");
            
            OpenRoom newOpenRoom = new OpenRoom()
            {
                FacilityId = openRoomDto.FacilityId,
                SeatCount = openRoomDto.SeatCount,  
            };

            if (_openRoomRepository.AddItem(newOpenRoom) != null)
            {
                for (int i = 1; i <= openRoomDto.SeatCount; ++i)
                {
                    OpenRoomSeatAllocation seat = new OpenRoomSeatAllocation
                    {
                        SeatNumber = string.Format("S{0:D3}", i),
                        OpenRoomId = newOpenRoom.OpenRoomId,
                        EmployeeId = null
                    };
                    _openRoomSeatMapRepository.AddItem(seat);
                }
            }
            else
                throw new ExceptionWhileAdding("Could not create open room");
        }

        public void UpdateItem(OpenRoomDto newOpenRoom)
        {
            var existingOpenRoom = _openRoomRepository.GetAllItems().FirstOrDefault(x=> x.OpenRoomId == newOpenRoom.OpenRoomId);

            if (existingOpenRoom == null)
                throw new ExceptionWhileUpdating("Open room doesn't exist");

            if (newOpenRoom.SeatCount > existingOpenRoom.SeatCount)
            {
                for (int i = existingOpenRoom.SeatCount + 1; i <= newOpenRoom.SeatCount; ++i)
                {
                    OpenRoomSeatAllocation seat = new OpenRoomSeatAllocation
                    {
                        SeatNumber = string.Format("S{0:D3}", i),
                        OpenRoomId = existingOpenRoom.OpenRoomId,
                        EmployeeId = null
                    };
                    _openRoomSeatMapRepository.AddItem(seat);
                }
                existingOpenRoom.SeatCount = newOpenRoom.SeatCount;
                _openRoomRepository.UpdateItem(existingOpenRoom);
            }
            else
                throw new ExceptionWhileUpdating("Seat count can only be increased at the moment");
        }
        private OpenRoomDto ConvertEntityToDto(OpenRoom openRoom)
        {
            return new OpenRoomDto()
            {
                OpenRoomId=openRoom.OpenRoomId,
                FacilityId=openRoom.FacilityId,
                SeatCount=openRoom.SeatCount,
            };
        }
        public void DeleteItem(string id)
        {
            /*refactoring needed
             var openRoom = _openRoomRepository.GetItemById(id);

             if (openRoom == null)
             return null;


             _openRoomRepository.DeleteItem(id);
             return openRoom;
            */
        }
    }
}



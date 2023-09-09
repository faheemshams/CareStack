using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;
using DataAccessLayer.Dto.ServiceDto;

namespace BuisnessLayer.Services
{
    public class OpenRoomService<Tin, Tout> : IService<OpenRoomDto, OpenRoom>
    {
        private readonly IRepository<OpenRoom> _openRoomRepository;
        private readonly IRepository<OpenRoomSeatAllocation> _openRoomSeatMapRepository;
         
        public OpenRoomService(IRepository<OpenRoom> _repository,IRepository<OpenRoomSeatAllocation> _seatRepository)
        {
            this._openRoomRepository = _repository;
            this._openRoomSeatMapRepository = _seatRepository;
        }
        public OpenRoom[] GetAllItems()
        {
            return _openRoomRepository.GetAllItems().ToArray();
        }

        public OpenRoom GetItem(string openRoomId)
        {
            if (int.TryParse(openRoomId, out int id))
            return _openRoomRepository.GetAllItems().FirstOrDefault(x => x.OpenRoomId == id);
            
            else
            return null;
        }

        public OpenRoom AddItem(OpenRoomDto openRoomDto)
        {
            if (_openRoomRepository.GetAllItems().FirstOrDefault(x => x.FacilityId == openRoomDto.FacilityId) != null)
            return null;
            
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
            return newOpenRoom;
        }

        public OpenRoom DeleteItem(string id)
        {
            /*refactoring needed
             var openRoom = _openRoomRepository.GetItemById(id);

             if (openRoom == null)
             return null;


             _openRoomRepository.DeleteItem(id);
             return openRoom;
            */
            return null;
        }

        public OpenRoom UpdateItem(OpenRoomDto newOpenRoom)
        {
            var existingOpenRoom = _openRoomRepository.GetAllItems().FirstOrDefault(x=> x.FacilityId == newOpenRoom.FacilityId);

            if (existingOpenRoom == null)
            return null;
            
            if(newOpenRoom.SeatCount > existingOpenRoom.SeatCount)
            {
                for (int i = existingOpenRoom.SeatCount+1; i <= newOpenRoom.SeatCount; ++i)
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
            return existingOpenRoom;
        }
    }
}



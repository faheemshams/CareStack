using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BuisnessLayer.Services
{
    public class OpenRoomService<T> : IService<OpenRoom>
    {
        private readonly IRepository<OpenRoom> _openRoomRepository;
        private readonly IRepository<OpenRoomSeatMap> _openRoomSeatMapRepository;
         
        public OpenRoomService(IRepository<OpenRoom> _repository,IRepository<OpenRoomSeatMap> _seatRepository)
        {
            this._openRoomRepository = _repository;
            this._openRoomSeatMapRepository = _seatRepository;
        }
        public OpenRoom[] GetAllItems()
        {
            return _openRoomRepository.GetAllItems().ToArray();
        }

        public OpenRoom GetItemById(int id)
        {
            return _openRoomRepository.GetItemById(id);
        }

        public OpenRoom AddItem(OpenRoom openRoom)
        {
            var alreadyExist = _openRoomRepository.GetItemById(openRoom.OpenRoomId);
            if (alreadyExist != null)
            return null;
            
            var createdOpenRoom = _openRoomRepository.AddItem(openRoom);

            if (createdOpenRoom == null)
            return null;

            for(int i=1; i<=openRoom.SeatCount; ++i)
            {
                OpenRoomSeatMap seat = new OpenRoomSeatMap
                {
                    SeatNumber = i,                   
                    OpenRoomId = createdOpenRoom.OpenRoomId,      
                    EmployeeId = null
                };
                _openRoomSeatMapRepository.AddItem(seat);
            }
            return openRoom;
        }

        public OpenRoom DeleteItem(int id)
        {
            var openRoom = _openRoomRepository.GetItemById(id);

            if (openRoom == null)
            return null;

            _openRoomRepository.DeleteItem(id);
            return openRoom;
        }

        public OpenRoom UpdateItem(OpenRoom newOpenRoom)
        {
            var existingOpenRoom = _openRoomRepository.GetItemById(newOpenRoom.OpenRoomId);

            if (existingOpenRoom == null)
            {
                return null;
            }

            existingOpenRoom.OpenRoomName = newOpenRoom.OpenRoomName;
            existingOpenRoom.FacilityId = newOpenRoom.FacilityId;
            
            if(newOpenRoom.SeatCount > existingOpenRoom.SeatCount)
            {
                existingOpenRoom.SeatCount = newOpenRoom.SeatCount;
                int seatNumber = _openRoomRepository.GetAllItems().ToArray().Length;

                for (int i = seatNumber; i <= newOpenRoom.SeatCount; ++i)
                {
                    OpenRoomSeatMap seat = new OpenRoomSeatMap
                    {
                        SeatNumber = i,
                        OpenRoomId = newOpenRoom.OpenRoomId,
                    };
                    _openRoomSeatMapRepository.AddItem(seat);
                }
            }
   
            _openRoomRepository.UpdateItem(existingOpenRoom);
            return newOpenRoom;
        }
    }
}



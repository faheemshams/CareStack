using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BuisnessLayer.Services
{
    public class CabinRoomService<T> : IService<CabinRoom>
    {
        private readonly IRepository<CabinRoom> _cabinRoomRepository;
        public CabinRoomService(IRepository<CabinRoom> _repository)
        {
            this._cabinRoomRepository = _repository;
        }
        public CabinRoom[] GetAllItems()
        {
            return _cabinRoomRepository.GetAllItems().ToArray();
        }

        public CabinRoom GetItemById(int id)             
        {
            return _cabinRoomRepository.GetItemById(id);
        }

        public CabinRoom AddItem(CabinRoom cabinRoom)
        {
            _cabinRoomRepository.AddItem(cabinRoom);
            return cabinRoom;
        }

        public CabinRoom DeleteItem(int id)
        {
            var cabinRoom = _cabinRoomRepository.GetItemById(id);

            if (cabinRoom == null)
                return null;

            _cabinRoomRepository.DeleteItem(id);
            return cabinRoom;
        }

        public CabinRoom UpdateItem(CabinRoom newCabinRoom)
        {
            var existingCabinRoom = _cabinRoomRepository.GetItemById(newCabinRoom.CabinId);

            if (existingCabinRoom == null)
            {
                return null;
            }

            existingCabinRoom.CabinName = newCabinRoom.CabinName;
            existingCabinRoom.FacilityId = newCabinRoom.FacilityId;
            existingCabinRoom.EmployeeId = newCabinRoom.EmployeeId; 

            _cabinRoomRepository.UpdateItem(existingCabinRoom);
            return newCabinRoom;
        }
    }
}



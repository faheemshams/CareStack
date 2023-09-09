using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Dto.ServiceDto;

namespace BuisnessLayer.Services
{
    public class OpenRoomSeatAllocationService<Tin, Tout> : IService<OpenRoomSeatAllocationDto, OpenRoomAllocation>
    {
        private readonly IRepository<OpenRoomSeatAllocation> _openRoomSeatMapRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public OpenRoomSeatAllocationService(IRepository<OpenRoomSeatAllocation> openRoomSeatMapRepository, IRepository<Employee> employeeRepository)
        {
            this._openRoomSeatMapRepository = openRoomSeatMapRepository;
            this._employeeRepository = employeeRepository;
        }

        public OpenRoomSeatAllocation[] GetAllItems()
        {
            return _openRoomSeatMapRepository.GetAllItems().ToArray();
        }

        public OpenRoomSeatAllocation GetItem(string seatNumber)
        {
            return _openRoomSeatMapRepository.GetAllItems().FirstOrDefault(x => x.SeatNumber == seatNumber);
        }

        public OpenRoomSeatAllocation AddItem(OpenRoomSeatAllocationDto openRoomSeatMap)
        {
            return null;
            //update fn contains allocation code
        }

        public OpenRoomSeatAllocation DeleteItem(int id)
        {
            //refactoring needed
            
            var openRoomSeatMap = _openRoomSeatMapRepository.GetItemById(id);

            if (openRoomSeatMap == null)
                return null;

            _openRoomSeatMapRepository.DeleteItem(id);
            return openRoomSeatMap;
        }

        public OpenRoomSeatAllocation UpdateItem(OpenRoomSeatAllocationDto newSeatAllocation)
        {
            var existingSeatAllocation = _openRoomSeatMapRepository.GetAllItems().FirstOrDefault(x => x.SeatNumber == newSeatAllocation.SeatNumber);
            var existingEmployee = _employeeRepository.GetItemById(newSeatAllocation.EmployeeId);

            if (existingSeatAllocation?.EmployeeId != null  || existingEmployee?.RoomTypeId != 1)
            return null;

            existingSeatAllocation.EmployeeId = newSeatAllocation.EmployeeId;
            existingEmployee.RoomTypeId = 2;

            _openRoomSeatMapRepository.UpdateItem(existingSeatAllocation);
            _employeeRepository.UpdateItem(existingEmployee);
            return existingSeatAllocation;
        }
    }
}

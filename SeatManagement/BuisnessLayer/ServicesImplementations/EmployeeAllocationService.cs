using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BuisnessLayer.Services
{
    public class EmployeeAllocationService<T> : IService<OpenRoomSeatMap>
    {
        private readonly IRepository<OpenRoomSeatMap> _openRoomSeatMapRepository;
        private readonly IRepository<Employee> _employeeRepository; 

        public EmployeeAllocationService(IRepository<OpenRoomSeatMap> openRoomSeatMapRepository, IRepository<Employee> employeeRepository)
        {
            _openRoomSeatMapRepository = openRoomSeatMapRepository;
            _employeeRepository = employeeRepository;
        }

        public OpenRoomSeatMap[] GetAllItems()
        {
            var openSeatList = _openRoomSeatMapRepository.GetAllItems().ToArray();
            return openSeatList;
        }

        public OpenRoomSeatMap GetItemById(int id)
        {
            return _openRoomSeatMapRepository.GetItemById(id);
        }

        public OpenRoomSeatMap AddItem(OpenRoomSeatMap openRoomSeatMap)
        {
            return null;
        }

        public OpenRoomSeatMap DeleteItem(int id)
        {
            var openRoomSeatMap = _openRoomSeatMapRepository.GetItemById(id);

            if (openRoomSeatMap == null)
                return null;

            _openRoomSeatMapRepository.DeleteItem(id);
            return openRoomSeatMap;
        }

        public OpenRoomSeatMap UpdateItem(OpenRoomSeatMap newSeatAllocation)
        {
            var existingSeatAllocation = _openRoomSeatMapRepository.GetItemById(newSeatAllocation.SeatId);
            var existingEmployee = _employeeRepository.GetItemById(newSeatAllocation.EmployeeId);

            if (existingSeatAllocation == null || existingEmployee == null)
            return null;

            existingSeatAllocation.SeatNumber = newSeatAllocation.SeatNumber;
            existingSeatAllocation.OpenRoomId = newSeatAllocation.OpenRoomId;
            existingSeatAllocation.EmployeeId = newSeatAllocation.EmployeeId;
            existingEmployee.RoomTypeId = 2;

            _openRoomSeatMapRepository.UpdateItem(existingSeatAllocation);
            _employeeRepository.UpdateItem(existingEmployee);
            return existingSeatAllocation;
        }
    }
}

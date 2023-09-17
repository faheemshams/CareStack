using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Dto.ServiceDto;

namespace BuisnessLayer.Services
{
    public class OpenRoomSeatAllocationService<Tin, Tout> : IService<OpenRoomSeatAllocationDto, OpenRoomSeatAllocation>
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

        public OpenRoomSeatAllocation GetItemById(int seatId)
        {
            return _openRoomSeatMapRepository.GetAllItems().FirstOrDefault(x => x.SeatId == seatId);
        }

        public OpenRoomSeatAllocation AddItem(OpenRoomSeatAllocationDto openRoomSeatMap)
        {
            return null;
            //update fn contains allocation code
        }

        public OpenRoomSeatAllocation DeleteItem(string id)
        {
            /*refactoring needed
            
            var openRoomSeatMap = _openRoomSeatMapRepository.GetItemById(id);

            if (openRoomSeatMap == null)
                return null;

            _openRoomSeatMapRepository.DeleteItem(id);  
            return openRoomSeatMap;*/
            return null;
        }

        public OpenRoomSeatAllocation UpdateItem(OpenRoomSeatAllocationDto newSeatAllocation)
        {
            
            var seat = _openRoomSeatMapRepository.GetAllItems().FirstOrDefault(x => x.OpenRoomId == newSeatAllocation.OpenRoomId && x.SeatNumber == newSeatAllocation.SeatNumber) ;
            var existingEmployee = _employeeRepository.GetItemById(newSeatAllocation.EmployeeId);

            if (seat?.EmployeeId != null  || existingEmployee?.RoomTypeId != 1)
            return null;

            seat.EmployeeId = newSeatAllocation.EmployeeId;
            existingEmployee.RoomTypeId = 2;

            _openRoomSeatMapRepository.UpdateItem(seat);
            _employeeRepository.UpdateItem(existingEmployee);
            return seat;
        }
    }
}

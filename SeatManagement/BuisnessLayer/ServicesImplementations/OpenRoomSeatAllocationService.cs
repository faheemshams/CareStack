using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace BuisnessLayer.Services
{
    public class OpenRoomSeatAllocationService<T> : IService<OpenRoomSeatAllocationDto>
    {
        private readonly IRepository<OpenRoomSeatAllocation> _openRoomSeatMapRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public OpenRoomSeatAllocationService(IRepository<OpenRoomSeatAllocation> openRoomSeatMapRepository, IRepository<Employee> employeeRepository)
        {
            this._openRoomSeatMapRepository = openRoomSeatMapRepository;
            this._employeeRepository = employeeRepository;
        }

        public OpenRoomSeatAllocationDto[] GetAllItems()
        {
            OpenRoomSeatAllocation[] seats = _openRoomSeatMapRepository.GetAllItems().ToArray();
            OpenRoomSeatAllocationDto[] seatDtos = new OpenRoomSeatAllocationDto[seats.Length];

            for(int i = 0; i < seatDtos.Length; i++)
            {
                seatDtos[i] = ConvertAllocationToAllocationDto(seats[i]);
            }
            return seatDtos;
        }

        public OpenRoomSeatAllocationDto GetItemById(int seatId)
        {
            var seat = _openRoomSeatMapRepository.GetAllItems().FirstOrDefault(x => x.SeatId == seatId);
            if (seat == null)
                throw new ExceptionWhileFetching("Seat is not found");
            else
                return ConvertAllocationToAllocationDto(seat);
        }

        public void UpdateItem(OpenRoomSeatAllocationDto newSeatAllocation)
        {
            var seat = _openRoomSeatMapRepository.GetAllItems().FirstOrDefault(x => x.OpenRoomId == newSeatAllocation.OpenRoomId && x.SeatNumber == newSeatAllocation.SeatNumber) ;
            var existingEmployee = _employeeRepository.GetItemById(newSeatAllocation.EmployeeId);

            if (seat == null)
                throw new ExceptionWhileUpdating("Seat not found");
            if (existingEmployee == null)
                throw new ExceptionWhileUpdating("Employee not found");
            if (existingEmployee.RoomTypeId != 1)
                throw new ExceptionWhileUpdating("Employee already seated");
            if (seat.EmployeeId != null)
                throw new ExceptionWhileUpdating("Seat already occupied");

            seat.EmployeeId = newSeatAllocation.EmployeeId;
            existingEmployee.RoomTypeId = 2;

            _openRoomSeatMapRepository.UpdateItem(seat);
            _employeeRepository.UpdateItem(existingEmployee);
        }
        private OpenRoomSeatAllocationDto ConvertAllocationToAllocationDto(OpenRoomSeatAllocation seat)
        {
            OpenRoomSeatAllocationDto seatDto = new OpenRoomSeatAllocationDto
            {
                OpenRoomId = seat.OpenRoomId,
                AllocationId = seat.SeatId,
                SeatNumber = seat.SeatNumber,
            };

            if (seat.EmployeeId != null)
                seatDto.EmployeeId = (int)seat.EmployeeId;
            return seatDto;
        }
        private OpenRoomSeatAllocationDto ConvertEntityToDto(OpenRoomSeatAllocation seat)
        {
            OpenRoomSeatAllocationDto seatDto = new OpenRoomSeatAllocationDto()
            {
                AllocationId = seat.SeatId,
                OpenRoomId = seat.OpenRoomId,
                SeatNumber = seat.SeatNumber,
            };
            if (seat.EmployeeId != null)
                seatDto.EmployeeId = (int)seat.EmployeeId;
            return seatDto;
        }
        public void AddItem(OpenRoomSeatAllocationDto openRoomSeatMap)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(string id)
        {
            throw new NotImplementedException();
        }
    }
}

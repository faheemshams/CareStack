﻿using SeatManagementConsole.Dto;
using SeatManagementConsole.Implementation;
using SeatManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public class Display
    {
        public void displayUnallocatedEmployee()
        {
            IAllocationManagerApi<EmployeeDto> employeeList = new SeatManagementAPICall<EmployeeDto>("Employee");
            var Employees = employeeList.GetItems();

            if (Employees != null)
            {
                var unAllocatedEmployees = Employees.Where(x => x.RoomType == 1).ToList();
                Console.WriteLine("\nUnallocated Employees\n");
                foreach (var employee in unAllocatedEmployees)
                {
                    Console.WriteLine(employee.EmployeeId + "\t" + employee.EmployeeName + "\t" + employee.DeptId);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No Employee is available for allocation.");
                return;
            }
        }
        public void displayAvailableOpenRooms()
        {
            IAllocationManagerApi<OpenRoomDto> openRooms = new SeatManagementAPICall<OpenRoomDto>("OpenRoom");
            Console.WriteLine("Available Open Rooms\n");

            var availableOpenRooms = openRooms.GetItems().ToArray();

            if (availableOpenRooms != null)
            {
                foreach (var room in availableOpenRooms)
                {
                    Console.WriteLine(room.OpenRoomId + "\t" + room.SeatCount + "\t" + room.FacilityId);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No open rooms available");
                return;
            }
        }
        public void diplayeEmptyOpenSeats()
        {
            IAllocationManagerApi<OpenRoomSeatAllocationDto> openSeatAllocation = new SeatManagementAPICall<OpenRoomSeatAllocationDto>("OpenRoomSeatMap");
            var availableOpenSeat = openSeatAllocation.GetItems();

            if (availableOpenSeat != null)
            {
                var unallocatedSeats = availableOpenSeat.Where(e => e.EmployeeId == null).ToList();
                Console.WriteLine("Available Open unallocated seats\n");
                foreach (var seat in unallocatedSeats)
                {
                    Console.WriteLine(seat.AllocationId + "\t" + seat.SeatNumber + "\t" + seat.OpenRoomId);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("All the seats are full");
            }
        }
        public void displayEmptyCabins()
        {
            IAllocationManagerApi<CabinRoomDto> cabinRoomList = new SeatManagementAPICall<CabinRoomDto>("CabinRoom");
            var cabinlist = cabinRoomList.GetItems();

            if (cabinlist != null)
            {
                var unallocatedCabins = cabinlist.Where(e => e.EmployeeId == null).ToList();
                foreach (var cabin in unallocatedCabins)
                {
                    Console.WriteLine(cabin.CabinNumber + "\t" + cabin.FacilityId);
                }
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine("Not available cabins");
        }
    }
}

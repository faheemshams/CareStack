using SeatManagementConsole.Dto.Cabin;
using SeatManagementConsole.Dto.Employee;
using SeatManagementConsole.Dto.OpenRoom;
using SeatManagementConsole.Dto.OpenRoomSeatAllocation;
using SeatManagementConsole.Implementation;
using SeatManagementConsole.Interfaces;
using System.Globalization;

namespace SeatManagementConsole
{
    internal class Allocate
    {
        public void AllocateEmployeeToSeat()
        {
            IAllocationManagerApi<OpenRoomAllocationDto> openSeatAllocation = new SeatManagementAPICall<OpenRoomAllocationDto>("OpenRoomSeatMap");
            IAllocationManagerApi<EmployeeDto> employeeData = new SeatManagementAPICall<EmployeeDto>("Employee");
            IAllocationManagerApi<OpenRoomDto> openRooms = new SeatManagementAPICall<OpenRoomDto>("OpenRoom");
            IAllocationManagerApi<AllocateOpenRoomAllocation> AllocateOpenRoomseat = new SeatManagementAPICall<AllocateOpenRoomAllocation>("OpenRoomSeatMap");

            var unAllocatedEmployees = employeeData.GetData().Where(e => e.RoomTypeId == 1).ToList();
            
            Console.WriteLine("\n Unallocated Employees\n");

            if (unAllocatedEmployees != null)
            {
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

            Console.WriteLine("Available Open Rooms\n");

            var availableOpenRooms = openRooms.GetData().ToArray();
            
            if (availableOpenRooms != null)
            {
                foreach (var room in availableOpenRooms)
                {
                    Console.WriteLine(room.OpenRoomId + "\t" + room.OpenRoomName + "\t" + room.SeatCount + "\t" + room.FacilityId);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No open rooms available");
                return;
            }

            Console.WriteLine("Available Open unallocated seats\n");

            var availableOpenSeat = openSeatAllocation.GetData().Where(e => e.EmployeeId == null).ToList(); 
            
            if(availableOpenSeat != null) 
            {
                foreach (var seat in availableOpenSeat)
                {
                    Console.WriteLine(seat.SeatId + "\t" + seat.SeatNumber + "\t" + seat.OpenRoomId);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("All the open rooms are full");
            }
           

            Console.WriteLine("Enter EmployeeId: ");
            int employeeid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Open room Id: ");
            int openRoomId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter SeatNumber: ");
            int seatno = Convert.ToInt32(Console.ReadLine());
            
            var seats = openSeatAllocation.GetData().Where(e=> e.SeatNumber == seatno && e.OpenRoomId == openRoomId).ToList();

            if (seats.Count() == 0)
            return;

            int seatId = seats[0].SeatId;

            var seatAllocate = new AllocateOpenRoomAllocation()
            {
                OpenRoomId = openRoomId,
                SeatNumber = seatno,
                EmployeeId = employeeid
            };
            Console.WriteLine(AllocateOpenRoomseat.Allocate(seatId, seatAllocate));
        }

        public void AllocateEmployeeToCabin()
        {
            IAllocationManagerApi<EmployeeDto> employeeList = new SeatManagementAPICall<EmployeeDto>("Employee");
            IAllocationManagerApi<CabinRoomDto> cabinRoomList = new SeatManagementAPICall<CabinRoomDto>("CabinRoom");
            IAllocationManagerApi<AllocateCabinRoomDto> allocateCabinRoom = new SeatManagementAPICall<AllocateCabinRoomDto>("CabinRoom");

            Console.WriteLine("\n Unallocated Employees\n");

            var unAllocatedEmployees = employeeList.GetData().Where(e => e.RoomTypeId == 1).ToList();

            if (unAllocatedEmployees != null)
            {
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

            Console.WriteLine("\nAvailable Cabins");
            
            var cabinlist = cabinRoomList.GetData().Where(e => e.EmployeeId == null).ToList();

            if (cabinlist != null)
            {
                foreach (var cabin in cabinlist)
                {
                    Console.WriteLine(cabin.CabinId + "\t" + cabin.CabinName + "\t" + cabin.FacilityId );
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("Enter the cabin id");
            int cabinId = Convert.ToInt32(Console.ReadLine());  
            Console.WriteLine("Enter Employee Id");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            var checkCabin = cabinRoomList.GetData().Where(s=> s.CabinId == cabinId).ToList();

            if (checkCabin == null)
            return;

            var cabinallocate = new AllocateCabinRoomDto
            {
               CabinName = checkCabin[0].CabinName,
               EmployeeId = employeeId,
               FacilityId = checkCabin[0].FacilityId
            };
            Console.WriteLine(allocateCabinRoom.Allocate(cabinId,cabinallocate));
        }
    }
}

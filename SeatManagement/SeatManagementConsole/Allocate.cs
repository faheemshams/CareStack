using SeatManagementConsole.Implementation;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Dto;

namespace SeatManagementConsole;

public class Allocate
{
    Display display = new Display();
    public void AllocateEmployeeToSeat()
    {
        IAllocationManagerApi<OpenRoomSeatAllocationDto> openSeatAllocation = new SeatManagementAPICall<OpenRoomSeatAllocationDto>("OpenRoomSeatMap");
        IAllocationManagerApi<EmployeeDto> employeeData = new SeatManagementAPICall<EmployeeDto>("Employee");
        IAllocationManagerApi<OpenRoomDto> openRooms = new SeatManagementAPICall<OpenRoomDto>("OpenRoom");

        display.displayUnallocatedEmployee();
        display.diplayeEmptyOpenSeats();
       
        Console.WriteLine("Enter EmployeeId: ");
        int employeeid = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Open room Id: ");
        int openRoomId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the seat number: ");
        string seatNumber = Console.ReadLine();   
        
        var seatAllocate = new OpenRoomSeatAllocationDto()
        {
            OpenRoomId = openRoomId,
            EmployeeId = employeeid,
            SeatNumber = seatNumber
        };
        Console.WriteLine(openSeatAllocation.UpdateItem(seatAllocate));
    }
    public void AllocateEmployeeToCabin()
    {
        IAllocationManagerApi<EmployeeDto> employeeList = new SeatManagementAPICall<EmployeeDto>("Employee");
        IAllocationManagerApi<CabinRoomDto> cabinRoomList = new SeatManagementAPICall<CabinRoomDto>("CabinRoom");
        IAllocationManagerApi<CabinRoomDto> allocateCabinRoom = new SeatManagementAPICall<CabinRoomDto>("CabinRoom");

        display.displayUnallocatedEmployee();
        display.displayEmptyCabins();
       
        Console.WriteLine("Enter the cabin id");
        int cabinId = Convert.ToInt32(Console.ReadLine());  
        Console.WriteLine("Enter Employee Id");
        int employeeId = Convert.ToInt32(Console.ReadLine());
        
        var cabinallocate = new CabinRoomDto()
        {
           EmployeeId = employeeId,
           CabinRoomId = cabinId
        };
        Console.WriteLine(allocateCabinRoom.UpdateItem(cabinallocate));
    }
}

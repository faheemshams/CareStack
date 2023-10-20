using SeatManagementConsole.Implementation;
using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Dto;
using System;

namespace SeatManagementConsole;

public class Allocate
{
    Display display = new Display();
    public void AllocateEmployeeToSeat()
    {
        IAllocationManagerApi<OpenRoomSeatAllocationDto> openSeatAllocation = new SeatManagementAPICall<OpenRoomSeatAllocationDto>("OpenRoomSeatMap");

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
    public void AllocateAsset()
    {
        IAllocationManagerApi<AssetDto> mapAssetToMeetingRoom = new SeatManagementAPICall<AssetDto>("Asset");

        Console.WriteLine("Enter Asset Id");
        int assetId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Meeting room id");
        int meetingRoomId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Quantity");
        int quantity = Convert.ToInt32(Console.ReadLine());

        var assetMap = new AssetDto()
        {
            LookUpAssetId = assetId,
            MeetingRoomId = meetingRoomId,
            Quantity = quantity
        };
        Console.WriteLine(mapAssetToMeetingRoom.AddItem(assetMap));
    }
}

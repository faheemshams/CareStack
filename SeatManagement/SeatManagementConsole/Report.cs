using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Dto.ReportDto;
using SeatManagementConsole.Implementation;

namespace SeatManagementConsole
{
    internal class Report
    {
        public void Allocatedreport()
        {
            IAllocationManagerApi<OpenRoomView> Allocatedreport = new SeatManagementAPICall<OpenRoomView>("OpenRoomView");
            var report = Allocatedreport.GetData();
            Console.WriteLine("Allocated Seats:\n");
            if (report != null)
            {
                foreach (var r in report)
                {
                    Console.WriteLine($"{r.CityAbbreviation}-{r.BuildingAbbreviation}-{r.Floor}-{r.FacilityName}-S{r.SeatNumber}");
                }
            }
            else
            {
                Console.WriteLine("No Allocated Seats");
            }
        }
        public void unAllocatedreport()
        {
            IAllocationManagerApi<UnAllocatedSeat> Allocatedreport = new SeatManagementAPICall<UnAllocatedSeat>("UnAllocated");
            var report = Allocatedreport.GetData();
            Console.WriteLine("UnAllocated Seats:\n");
            if (report != null)
            {
                foreach (var r in report)
                {
                    Console.WriteLine($"{r.CityAbbreviation}-{r.BuildingAbbreviation}-{r.Floor}-{r.FacilityName}-S{r.SeatNumber}");
                }
            }
            else
            {
                Console.WriteLine("No UnAllocated Seats.");
            }
        }
    }
}


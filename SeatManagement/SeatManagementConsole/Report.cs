using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    internal class Report
    {
        public void Allocatedreport()
        {
            IAllocationManagerApi<AllocatedSeat> Allocatedreport = new SeatManagementAPICall<AllocatedSeat>("Allocated");
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


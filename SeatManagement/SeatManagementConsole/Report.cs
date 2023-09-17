using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Dto.ReportDto;
using SeatManagementConsole.Implementation;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using SeatManagementConsole.Dto;

namespace SeatManagementConsole
{
    public class Report
    {
        void addFilters()
        {
            Console.WriteLine("Enter filters if needed or press Enter");

            Console.WriteLine("Seat type : All | OpenRoom | CabinRoom");
            string seatType = Console.ReadLine();
            Console.WriteLine("City abbrevation if any");
            string city = Console.ReadLine();
            Console.WriteLine("Floor if any");
            int Floor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Seat State : All | Free | Allocated");
            string seatState = Console.ReadLine();
            Console.WriteLine("Facility name if any");
            string FacilityName = Console.ReadLine();

            FilterConditionsDto filterConditionsDto = new FilterConditionsDto();

            if(seatType == "OpenRoom")
                filterConditionsDto.SeatType = seatType;
            else if (seatType == "CabinRoom")
                filterConditionsDto.SeatType= seatType;
            if (!city.Equals("\n"))
                filterConditionsDto.Locations = city;
            if (Floor != 0)
                filterConditionsDto.Floor = Floor;
            if (!seatState.Equals("\n"))
                filterConditionsDto.SeatState = seatState;
            if(!FacilityName.Equals("\n"))
                filterConditionsDto.FacilityName = FacilityName;        
        }

        void getReport(FilterConditionsDto filters)
        {
            var json = JsonConvert.SerializeObject(filters);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(apiEndpoint, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return "Added a new entry.";
            }
            return response.Content.ReadAsStringAsync().Result;

        }
            catch (Exception ex)
            {
                return ex.Message;
            }
}
        
          
            


            
            
            
            
            
            
            
            
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(apiEndpoint, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return "Added a new entry.";
            }
            return response.Content.ReadAsStringAsync().Result;

        }
            catch (Exception ex)
            {
                return ex.Message;
            }
}
        
        
        
        
        
        
        
        
        
        
        /*public void Allocatedreport()
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
        }*/
    }
}


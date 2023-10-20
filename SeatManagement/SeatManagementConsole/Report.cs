using SeatManagementConsole.Interfaces;
using SeatManagementConsole.Implementation;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using SeatManagementConsole.Dto;

namespace SeatManagementConsole
{
    public class Report
    {
        public void addFilters()
        {
            Console.WriteLine("\nENTER FILTERS IF NEEDED | ENTER\n");

            Console.WriteLine("Seat type : All | OpenRoom | CabinRoom");
            string seatType = Console.ReadLine();
            Console.WriteLine("City abbrevation if any");
            string city = Console.ReadLine();
            Console.WriteLine("Floor if any | 0");
            int Floor = 0;
            try
            {
                Floor = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception) { }
           
            Console.WriteLine("Seat State : All | Free | Allocated"); 
            string seatState = Console.ReadLine();
            Console.WriteLine("Facility name if any");
            string FacilityName = Console.ReadLine();
            getReportAsync(seatType, city, Floor, seatState, FacilityName);
        }

        async Task getReportAsync(string seatType, string city, int Floor, string seatState, string FacilityName)
        {
            
            string apiUrl = "https://localhost:7225/api/Report";

            using(var httpClient = new HttpClient())
            {
                apiUrl = $"{apiUrl}?SeatType={seatType}&City={city}&Floor={Floor}&SeatState={seatState}&FacilityName={FacilityName}";
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    var responseDtos = JsonConvert.DeserializeObject<List<ReportView>>(responseJson);

                    Console.WriteLine("\n\nSEAT NUMBER\tEMPLOYEE NAME\tEMPLOYEE ID\tFACILITY NAME\tFLOOR");

                    foreach(var dto in responseDtos)
                    {
                        Console.WriteLine(dto.CityAbbreviation+"-"+dto.BuildingAbbreviation+"-"+dto.SeatNumber + "\t" + dto.EmployeeName + "\t\t\t" + dto.EmployeeId + "\t" + dto.FacilityName + "\t"+ dto.Floor);
                    }
                }
                else
                {
                    Console.WriteLine($"API request failed: {response.StatusCode}");
                }
            }
        }
    }
}


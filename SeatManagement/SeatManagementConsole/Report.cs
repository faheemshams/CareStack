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
            Console.WriteLine("Enter filters if needed or press Enter");

            Console.WriteLine("Seat type : All | OpenRoom | CabinRoom");
            string seatType = Console.ReadLine();
            Console.WriteLine("City abbrevation if any");
            string city = Console.ReadLine();
            Console.WriteLine("Floor if any | 0");
            int Floor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Seat State : All | Free | Allocated");
            string seatState = Console.ReadLine();
            Console.WriteLine("Facility name if any");
            string FacilityName = Console.ReadLine();

            FilterConditionsDto filterConditionsDto = new FilterConditionsDto();
            {

            }

            if(seatType == "OpenRoom")
                filterConditionsDto.SeatType = seatType;
            else if (seatType == "CabinRoom")
                filterConditionsDto.SeatType= seatType;
            if (!city.Equals(""))
                filterConditionsDto.Locations = city;
            if (Floor != 0)
                filterConditionsDto.Floor = Floor;
            if (!seatState.Equals(""))
                filterConditionsDto.SeatState = seatState;
            if(!FacilityName.Equals(""))
                filterConditionsDto.FacilityName = FacilityName;        

            getReportAsync(filterConditionsDto);
        }

        async Task getReportAsync(FilterConditionsDto filters)
        {
            var requestJson = JsonConvert.SerializeObject(filters);
            string apiUrl = "https://localhost:7225/api/Report";

            using(var httpClient = new HttpClient())
            {
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    var responseDtos = JsonConvert.DeserializeObject<List<ReportView>>(responseJson);

                    Console.WriteLine("\nSEAT NUMBER\tEMPLOYEE NAME\tEMPLOYEE ID\tFACILITY NAME\tFLOOR");

                    foreach(var dto in responseDtos)
                    {
                        Console.WriteLine(dto.CityAbbreviation+ "-"+dto.BuildingAbbreviation+"-"+dto.SeatNumber + "\t" + dto.EmployeeName + "\t\t\t" + dto.EmployeeId + "\t" + dto.FacilityName + "\t"+ dto.Floor);
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


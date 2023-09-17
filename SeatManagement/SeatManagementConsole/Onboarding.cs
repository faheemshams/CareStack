using SeatManagementConsole.Dto;
using SeatManagementConsole.Implementation;
using SeatManagementConsole.Interfaces;

namespace SeatManagementConsole
{
    internal class Onboarding
    {
        public void OnboardFacility()
        {
            IAllocationManagerApi<FacilityDto> facilityManager = new SeatManagementAPICall<FacilityDto>("Facility");
            IAllocationManagerApi<CityDto> citymanager = new SeatManagementAPICall<CityDto>("City");
            IAllocationManagerApi<BuildingDto> buildingmanager = new SeatManagementAPICall<BuildingDto>("Building");

            var citylist = citymanager.GetItems();
            var buildinglist = buildingmanager.GetItems();

            Console.WriteLine("\n<----- * Available Buildings * ----->");
            
            foreach (var building in buildinglist)
            {
                Console.WriteLine(building.BuildingId + "\t" + building.BuildingName + "\t" + building.BuildingAbbreviation + "\t" + building.FloorCount);
            }
            Console.WriteLine("\n");

            Console.WriteLine("\n<----- * Available Cities * ----->");
            foreach (var city in citylist)
            {
                Console.WriteLine(city.CityId + "\t" + city.CityName + "\t" + city.CityName);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Enter BuildingId: ");
            int Buildingid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter CityId: ");
            int CityId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Floor number: ");
            int floorno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Facility Name: ");
            string facilityname = Console.ReadLine();

            var item = new FacilityDto
            {
                FacilityName = facilityname,
                Floor = floorno,
                BuildingId = Buildingid,
                CityId = CityId
            };

            Console.WriteLine(facilityManager.AddItem(item));
        }
        public void OnboardOpenSeats()
        {
            IAllocationManagerApi<OpenRoomDto> addseat = new SeatManagementAPICall<OpenRoomDto>("OpenRoom");
            Console.WriteLine("Enter facility id:");
            int facilityid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of seats: ");
            int seatCount = Convert.ToInt32(Console.ReadLine());

            var openRoom = new OpenRoomDto
            {
                FacilityId = facilityid,
                SeatCount = seatCount
            };

            Console.WriteLine(addseat.AddItem(openRoom));
        }
        public void OnboardMeetingroom()
        {
            IAllocationManagerApi<MeetingRoomDto> addmeetingroom = new SeatManagementAPICall<MeetingRoomDto>("Meetingroom");

            Console.WriteLine("Enter number of seats: ");
            int seatCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
          
            var meetingroom = new MeetingRoomDto
            {
                FacilityId = facilityid,
                SeatCount = seatCount
            };

            Console.WriteLine(addmeetingroom.AddItem(meetingroom));
        }
        public void OnboardCabin()
        {
            IAllocationManagerApi<CabinRoomDto> addcabin = new SeatManagementAPICall<CabinRoomDto>("CabinRoom");

            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
           
            var cabin = new CabinRoomDto
            {
                FacilityId = facilityid,
            };

            Console.WriteLine(addcabin.AddItem(cabin));
        }
        public void OnboardEmployee()
        {
            IAllocationManagerApi<EmployeeDto> addemployee = new SeatManagementAPICall<EmployeeDto>("Employee");

            Console.WriteLine("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter DepartmentId: ");
            int departmentid = Convert.ToInt32(Console.ReadLine());

            var employee = new EmployeeDto
            {
                EmployeeName = name,
                DeptId = departmentid,
            };

            Console.WriteLine(addemployee.AddItem(employee));
        } 
    }
}

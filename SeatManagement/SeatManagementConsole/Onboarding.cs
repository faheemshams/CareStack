using SeatManagementConsole.Dto.Building;
using SeatManagementConsole.Dto.Cabin;
using SeatManagementConsole.Dto.City;
using SeatManagementConsole.Dto.Employee;
using SeatManagementConsole.Dto.Facility;
using SeatManagementConsole.Dto.MeetingRoom;
using SeatManagementConsole.Dto.OpenRoom;
using SeatManagementConsole.Implementation;
using SeatManagementConsole.Interfaces;

namespace SeatManagementConsole
{
    internal class Onboarding
    {
        public void OnboardFacility()
        {
            IAllocationManagerApi<CreateFacilityDto> facilityManager = new SeatManagementAPICall<CreateFacilityDto>("Facility");
            IAllocationManagerApi<City> citymanager = new SeatManagementAPICall<City>("City");
            IAllocationManagerApi<Building> buildingmanager = new SeatManagementAPICall<Building>("Building");

            var citylist = citymanager.GetData();
            var buildinglist = buildingmanager.GetData();

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

            var item = new CreateFacilityDto
            {
                FacilityName = facilityname,
                Floor = floorno,
                BuildingId = Buildingid,
                CityId = CityId
            };

            Console.WriteLine(facilityManager.CreateData(item));
        }
        public void OnboardOpenSeats()
        {
            IAllocationManagerApi<OpenRoomDto> addseat = new SeatManagementAPICall<OpenRoomDto>("OpenRoom");

            Console.WriteLine("Enter Openroom name:");
            string openRoomName = Console.ReadLine();
            Console.WriteLine("Enter facility id:");
            int facilityid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of seats: ");
            int seatCount = Convert.ToInt32(Console.ReadLine());

            var openRoom = new OpenRoomDto
            {
                OpenRoomName = openRoomName,
                FacilityId = facilityid,
                SeatCount = seatCount
            };

            Console.WriteLine(addseat.CreateData(openRoom));
        }
        public void OnboardMeetingroom()
        {
            IAllocationManagerApi<MeetingRoomDto> addmeetingroom = new SeatManagementAPICall<MeetingRoomDto>("Meetingroom");

            Console.WriteLine("Enter Meeting Room name: ");
            string meetingRoomName = Console.ReadLine();
            Console.WriteLine("Enter number of seats: ");
            int seatCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
          
            var meetingroom = new MeetingRoomDto
            {
                FacilityId = facilityid,
                MeetingRoomName = meetingRoomName,
                SeatCount = seatCount
            };

            Console.WriteLine(addmeetingroom.CreateData(meetingroom));
        }
        public void OnboardCabin()
        {
            IAllocationManagerApi<CabinRoomDto> addcabin = new SeatManagementAPICall<CabinRoomDto>("CabinRoom");

            Console.WriteLine("Enter Cabin name: ");
            string cabinName = Console.ReadLine();
            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
           
            var cabin = new CabinRoomDto
            {
                FacilityId = facilityid,
                CabinName = cabinName
            };

            Console.WriteLine(addcabin.CreateData(cabin));
        }
        public void OnboardEmployee()
        {
            IAllocationManagerApi<CreateEmployeeDto> addemployee = new SeatManagementAPICall<CreateEmployeeDto>("Employee");

            Console.WriteLine("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter DepartmentId: ");
            int departmentid = Convert.ToInt32(Console.ReadLine());

            var employee = new CreateEmployeeDto
            {
                EmployeeName = name,
                DeptId = departmentid,
            };

            Console.WriteLine(addemployee.CreateData(employee));
        } 
    }
}

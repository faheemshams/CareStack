namespace SeatManagementConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Onboarding onboarding = new Onboarding();
            Allocate allocation = new Allocate();
            Report reporting = new Report();

            Console.WriteLine("Welcome to the Seat Management System!");
            while (true)
            {
                Console.WriteLine("\n<--- Main Menu --->");
                Console.WriteLine("1. Onboard Employee");
                Console.WriteLine("2. Onboard a Facility");
                Console.WriteLine("3. Onboard Open Seats");
                Console.WriteLine("4. Onboard Cabins");
                Console.WriteLine("5. Onboard Meeting Rooms");
                Console.WriteLine("6. Allocate Employee to Open room");
                Console.WriteLine("7. Allocate Employee to Cabin room");
                Console.WriteLine("8. Allocate asset to Meeting room");
                Console.WriteLine("9. Generate Reports");
                Console.WriteLine("10.Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": onboarding.OnboardEmployee();
                              break; 
                    case "2": onboarding.OnboardFacility();
                              break;
                    case "3": onboarding.OnboardOpenSeats();
                              break;
                    case "4": onboarding.OnboardCabin();
                              break;
                    case "5": onboarding.OnboardMeetingroom();
                              break;
                    case "6": allocation.AllocateEmployeeToSeat();
                              break;
                    case "7": allocation.AllocateEmployeeToCabin();
                              break;
                    case "8": allocation.AllocateAsset();
                              break;
                    case "9": reporting.addFilters();
                              break;
                    case "10":Environment.Exit(0);
                              break;
                    default:  Console.WriteLine("Invalid choice. Please try again.");
                              break;
                }
            }
        }
    }
}
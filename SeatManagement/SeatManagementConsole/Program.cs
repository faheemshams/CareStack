namespace SeatManagementConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Onboarding onboarding = new Onboarding();
            Allocate allocation = new Allocate();
            //Report reporting = new Report();

            Console.WriteLine("Welcome to the Seat Management System!");
            while (true)
            {
                Console.WriteLine("\n<--- Main Menu --->");
                Console.WriteLine("1. Onboard Employee");
                Console.WriteLine("2. Onboard a Facility");
                Console.WriteLine("3. Onboard Open Seats");
                Console.WriteLine("4. Onboard Cabins");
                Console.WriteLine("5. Onboard Meeting Rooms");
                Console.WriteLine("6. Allocate Employee");
                Console.WriteLine("7. UnAllocate Employee");
                Console.WriteLine("8. Generate Reports");
                Console.WriteLine("9. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        onboarding.OnboardEmployee();
                        break;

                    case "2":
                        onboarding.OnboardFacility();
                        break;

                    case "3":
                        onboarding.OnboardOpenSeats();
                        break;

                    case "4":
                        onboarding.OnboardCabin();
                        break;

                    case "5":
                        onboarding.OnboardMeetingroom();
                        break;

                    case "6":
                        Console.WriteLine("1.Allocate to Seat\n2.Allocate to cabin\n");
                        int allocationInput = Convert.ToInt32(Console.ReadLine());

                        if (allocationInput == 1)
                        {
                            allocation.AllocateEmployeeToSeat();

                        }
                        else if (allocationInput == 2)
                        {
                           allocation.AllocateEmployeeToCabin();

                        }
                        else
                        {
                            Console.WriteLine("Enter Valid Input.");
                        }
                        break;

                    case "7":
                        
                        
                        
                        
                        /*
                        Console.WriteLine("Generate Report For \n1.AllocatedSeat\n2.UnAllocatedSeat\n");
                        int input = Convert.ToInt32(Console.ReadLine());
                        if (input == 1)
                        {
                            reporting.Allocatedreport();
                        }
                        else if (input == 2)
                        {
                            reporting.unAllocatedreport();
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid input");
                        }*/
                        break;

                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

//namespace ClubManagement.TestApp
//{
//    public class FlightBookingApplicationService : ChoiceSystemBase, IPayerManagerService
//    {
//        private const string AirportChoice = "1";
//        private const string BookingChoice = "2";
//        private const string CustomerChoice = "3";
//        private const string FlightChoice = "4";
//        private const string ExitChoice = "5";

//        private readonly IClubManagerService airportManagerService;
//        private readonly ITeamManagerService bookingManagerService;
//        private readonly IPitchManagerService customerManagerService;
//        private readonly ICoachManagerService flightManagerService;

//        public FlightBookingApplicationService(IClubManagerService airportManagerService,
//            ITeamManagerService bookingManagerService,
//            IPitchManagerService customerManagerService,
//            ICoachManagerService flightManagerService)
//        {
//            this.airportManagerService = airportManagerService;
//            this.bookingManagerService = bookingManagerService;
//            this.customerManagerService = customerManagerService;
//            this.flightManagerService = flightManagerService;
//        }

//        public async Task RunAsync()
//        {
//            Console.Clear();

//            while (true)
//            {
//                Console.WriteLine("Welcome to the flight booking application created for the purpose of showing how .NET's Entity Framework can be used in enterprise applications as part of isolutions' Modern IT Academy - Entity Framework module.\n");

//                Console.WriteLine("Please choose which part of the application you want to manage.\n");
//                Console.WriteLine($"{AirportChoice} - Airports");
//                Console.WriteLine($"{BookingChoice} - Bookings");
//                Console.WriteLine($"{CustomerChoice} - Customers");
//                Console.WriteLine($"{FlightChoice} - Flights");
//                Console.WriteLine($"{ExitChoice} - Exit\n");

//                if (!CorrectChoiceMade)
//                {
//                    Console.WriteLine("You previously made an incorrect choice. Please provide one of the options and hit enter.\n");
//                }

//                Console.Write("Your choice (1-5): ");

//                var choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case AirportChoice:
//                        await airportManagerService.RunAsync();
//                        ResetChoiceMade();
//                        break;
//                    case BookingChoice:
//                        await bookingManagerService.RunAsync();
//                        ResetChoiceMade();
//                        break;
//                    case CustomerChoice:
//                        await customerManagerService.RunAsync();
//                        ResetChoiceMade();
//                        break;
//                    case FlightChoice:
//                        await flightManagerService.RunAsync();
//                        ResetChoiceMade();
//                        break;
//                    case ExitChoice:
//                        Console.WriteLine("Closing the application. Thank you!");
//                        return;
//                    default:
//                        ChoiceMadeIncorrectly();
//                        break;
//                }
//            }
//        }
//    }
//}



//namespace ClubManagement.TestApp.Services
//{ 
//    public class AirportManagerService : ManagerServiceBase<Airport>, IClubManagerService
//    {
//        public AirportManagerService(FlightBookingContext context, IAirportRepository airportRepository)
//            : base(context, airportRepository)
//        {
//        }

//        public override Task WriteEntityToConsoleAsync(Airport entity, string? prefix = null)
//        {
//            if (!string.IsNullOrEmpty(prefix))
//            {
//                Console.WriteLine(prefix);
//            }

//            Console.WriteLine($"Id: {entity.Id}");
//            Console.WriteLine($"City: {entity.City}");
//            Console.WriteLine($"IATA: {entity.IATA}");

//            Console.WriteLine();

//            return Task.CompletedTask;
//        }

//        protected override Task<Airport?> GetCreateEntityFromUser()
//        {
//            Console.Write("Please provide a city: ");
//            var city = Console.ReadLine();

//            Console.Write("Please provide an IATA code (example: \"ABC\"): ");
//            var iata = Console.ReadLine();

//            var result = new Airport
//            {
//                City = city ?? "NoCity",
//                IATA = iata ?? "ABC"
//            };

//            return Task.FromResult<Airport?>(result);
//        }

//        protected override Task<Airport> GetUpdateEntityFromUser(Airport entity)
//        {
//            Console.Write("Please provide a city: ");
//            var city = Console.ReadLine();

//            Console.WriteLine("Please provide an IATA code (example: \"ABC\"): ");
//            var iata = Console.ReadLine();

//            entity.City = city ?? entity.City;
//            entity.IATA = iata ?? entity.IATA;

//            return Task.FromResult(entity);
//        }
//    }
//}

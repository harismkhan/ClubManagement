
//namespace ClubManagement.TestApp
//{
//    public class FlightManagerService : ManagerServiceBase<Flight>, ICoachManagerService
//    {
//        private readonly IFlightRepository flightRepository;
//        private readonly IClubManagerService airportManagerService;
//        private readonly IPitchManagerService customerManagerService;

//        public FlightManagerService(FlightBookingContext context,
//            IFlightRepository flightRepository,
//            IClubManagerService airportManagerService,
//            IPitchManagerService customerManagerService)
//            : base(context, flightRepository)
//        {
//            this.flightRepository = flightRepository;
//            this.airportManagerService = airportManagerService;
//            this.customerManagerService = customerManagerService;
//        }

//        public override async Task WriteEntityToConsoleAsync(Flight entity, string? prefix = null)
//        {
//            if (!string.IsNullOrEmpty(prefix))
//            {
//                Console.WriteLine(prefix);
//            }

//            Console.WriteLine($"Id: {entity.Id}");

//            var origin = await flightRepository.GetOtherAsync<Airport>(entity.OriginId);
//            var destination = await flightRepository.GetOtherAsync<Airport>(entity.DestinationId);
//            var bookings = await flightRepository.GetAllBookingsAsync(entity.Id);

//            await airportManagerService.WriteEntityToConsoleAsync(origin!, "Origin - ");
//            await airportManagerService.WriteEntityToConsoleAsync(destination!, "Destination -");

//            if (bookings is not null)
//            {
//                Console.WriteLine("Bookings - ");
//                foreach (var booking in bookings)
//                {
//                    await customerManagerService.WriteEntityToConsoleAsync(booking.Customer);
//                }
//            }

//            Console.WriteLine();
//        }

//        protected override async Task<Flight?> GetCreateEntityFromUser()
//        {
//            var airports = await airportManagerService.ReadAsync();

//            if (!airports.Any())
//            {
//                return null;
//            }

//            Console.WriteLine("Origin - ");
//            var originChoice = airportManagerService.GetChoiceFromData(airports);

//            Console.WriteLine("Destination - ");
//            var destinationChoice = airportManagerService.GetChoiceFromData(airports);

//            return new Flight
//            {
//                Origin = airports.ElementAt(originChoice - 1),
//                Destination = airports.ElementAt(destinationChoice - 1)
//            };
//        }

//        protected override async Task<Flight> GetUpdateEntityFromUser(Flight entity)
//        {
//            var flights = await airportManagerService.ReadAsync();

//            Console.WriteLine("Origin - ");
//            var originChoice = airportManagerService.GetChoiceFromData(flights);

//            Console.WriteLine("Destination - ");
//            var destinationChoice = airportManagerService.GetChoiceFromData(flights);

//            entity.Origin = flights.ElementAt(originChoice - 1);
//            entity.OriginId = Guid.Empty;

//            entity.Destination = flights.ElementAt(destinationChoice - 1);
//            entity.DestinationId = Guid.Empty;

//            return entity;
//        }
//    }
//}



//namespace ClubManagement.TestApp
//{
//    public class BookingManagerService : ManagerServiceBase<Booking>, ITeamManagerService
//    {
//        private readonly IBookingRepository bookingRepository;
//        private readonly ICoachManagerService flightManagerService;
//        private readonly IPitchManagerService customerManagerService;

//        public BookingManagerService(FlightBookingContext context,
//            IBookingRepository bookingRepository,
//            ICoachManagerService flightManagerService,
//            IPitchManagerService customerManagerService)
//            : base(context, bookingRepository)
//        {
//            this.bookingRepository = bookingRepository;
//            this.flightManagerService = flightManagerService;
//            this.customerManagerService = customerManagerService;
//        }

//        public override async Task WriteEntityToConsoleAsync(Booking entity, string? prefix = null)
//        {
//            if (!string.IsNullOrEmpty(prefix))
//            {
//                Console.WriteLine(prefix);
//            }

//            Console.WriteLine($"Id: {entity.Id}");

//            var flight = await bookingRepository.GetOtherAsync<Flight>(entity.FlightId);
//            var customer = await bookingRepository.GetOtherAsync<Customer>(entity.CustomerId);

//            await flightManagerService.WriteEntityToConsoleAsync(flight!, "Flight - ");
//            await customerManagerService.WriteEntityToConsoleAsync(customer!, "Customer -");

//            Console.WriteLine();
//        }

//        protected override async Task<Booking?> GetCreateEntityFromUser()
//        {
//            var flights = await flightManagerService.ReadAsync();

//            if (!flights.Any())
//            {
//                return null;
//            }

//            var flightChoice = flightManagerService.GetChoiceFromData(flights);

//            var customers = await customerManagerService.ReadAsync();

//            if (!customers.Any())
//            {
//                return null;
//            }

//            var customerChoice = customerManagerService.GetChoiceFromData(customers);

//            return new Booking
//            {
//                Flight = flights.ElementAt(flightChoice - 1),
//                Customer = customers.ElementAt(customerChoice - 1)
//            };
//        }

//        protected override async Task<Booking> GetUpdateEntityFromUser(Booking entity)
//        {
//            var flights = await flightManagerService.ReadAsync();
//            var flightChoice = flightManagerService.GetChoiceFromData(flights);

//            var customers = await customerManagerService.ReadAsync();
//            var customerChoice = customerManagerService.GetChoiceFromData(customers);

//            entity.Flight = flights.ElementAt(flightChoice - 1);
//            entity.FlightId = Guid.Empty;

//            entity.Customer = customers.ElementAt(customerChoice - 1);
//            entity.CustomerId = Guid.Empty;

//            return entity;
//        }
//    }
//}

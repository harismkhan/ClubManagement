

//namespace ClubManagement.TestApp
//{
//    public class CustomerManagerService : ManagerServiceBase<Customer>, IPitchManagerService
//    {
//        public CustomerManagerService(FlightBookingContext context, ICustomerRepository customerRepository)
//            : base(context, customerRepository)
//        {
//        }

//        public override Task WriteEntityToConsoleAsync(Customer entity, string? prefix = null)
//        {
//            if (!string.IsNullOrEmpty(prefix))
//            {
//                Console.WriteLine(prefix);
//            }

//            Console.WriteLine($"Id: {entity.Id}");
//            Console.WriteLine($"First name: {entity.FirstName}");
//            Console.WriteLine($"Last name: {entity.LastName}");
//            Console.WriteLine($"Email: {entity.Email}");

//            Console.WriteLine();

//            return Task.CompletedTask;
//        }

//        protected override Task<Customer?> GetCreateEntityFromUser()
//        {
//            Console.Write("Please provide a first name: ");
//            var firstName = Console.ReadLine();

//            Console.Write("Please provide a last name: ");
//            var lastName = Console.ReadLine();

//            Console.Write("Please provide an email address: ");
//            var email = Console.ReadLine();

//            var result = new Customer
//            {
//                FirstName = firstName ?? "NoFirstName",
//                LastName = lastName ?? "NoLastName",
//                Email = email ?? "NoEmailAddress"
//            };

//            return Task.FromResult<Customer?>(result);
//        }

//        protected override Task<Customer> GetUpdateEntityFromUser(Customer entity)
//        {
//            Console.Write("Please provide a first name: ");
//            var firstName = Console.ReadLine();

//            Console.Write("Please provide a last name: ");
//            var lastName = Console.ReadLine();

//            Console.WriteLine("Please provide an email address: ");
//            var email = Console.ReadLine();

//            entity.FirstName = firstName ?? entity.FirstName;
//            entity.FirstName = lastName ?? entity.LastName;
//            entity.Email = email ?? entity.Email;

//            return Task.FromResult(entity);
//        }
//    }
//}

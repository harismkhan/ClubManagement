
//using ClubManagement.Backbone;
//using ClubManagement.Contexts;
//using ClubManagement.Repositories.Interfaces;

//namespace ClubManagement.TestApp
//{
//    public abstract class ManagerServiceBase<TEntity> : ChoiceSystemBase, IPlayerManagerService
//        where TEntity : Entity
//    {
//        protected const string CreateChoice = "1";
//        protected const string ReadChoice = "2";
//        protected const string UpdateChoice = "3";
//        protected const string DeleteChoice = "4";
//        protected const string ExitChoice = "5";

//        protected readonly string EntityName = typeof(TEntity).Name.ToLower();
//        protected readonly string EntityNamePlural = (typeof(TEntity).Name + "s").ToLower();

//        private readonly ClubManagementContext context;
//        private readonly IBaseRepository<TEntity> repository;

//        public ManagerServiceBase(ClubManagementContext context, IBaseRepository<TEntity> repository)
//        {
//            this.context = context;
//            this.repository = repository;
//        }

//        public async Task RunAsync()
//        {
//            Console.Clear();

//            while (true)
//            {
//                Console.WriteLine($"Welcome to the part of the flight booking application from where {EntityNamePlural} can be managed.\n");

//                var choice = GetChoice();

//                switch (choice)
//                {
//                    case CreateChoice:
//                        await CreateAsync();
//                        await context.SaveChangesAsync();
//                        ReturnToManagerHomeScreen();
//                        break;
//                    case ReadChoice:
//                        await ReadAsync();
//                        await context.SaveChangesAsync();
//                        ReturnToManagerHomeScreen();
//                        break;
//                    case UpdateChoice:
//                        await UpdateAsync();
//                        await context.SaveChangesAsync();
//                        ReturnToManagerHomeScreen();
//                        break;
//                    case DeleteChoice:
//                        await DeleteAsync();
//                        await context.SaveChangesAsync();
//                        ReturnToManagerHomeScreen();
//                        break;
//                    case ExitChoice:
//                        ReturnToHomeScreen();
//                        return;
//                    default:
//                        ChoiceMadeIncorrectly();
//                        break;
//                }
//            }
//        }

//        public async Task<TEntity?> CreateAsync()
//        {
//            Console.WriteLine($"You are now creating a new {EntityName}.\n");

//            var newEntity = await GetCreateEntityFromUser();

//            if (newEntity is null)
//            {
//                Console.WriteLine($"The new {EntityName} can not be created due to a lack of data.\n");
//                return null;
//            }

//            repository.Add(newEntity);

//            return newEntity;
//        }

//        public async Task<IEnumerable<TEntity>> ReadAsync()
//        {
//            Console.WriteLine($"Listing all the {EntityNamePlural}...\n");

//            var items = await repository.GetAllAsync();

//            if (!items.Any())
//            {
//                Console.WriteLine($"No {EntityNamePlural}.");
//            }

//            var index = 1;
//            foreach (var item in items)
//            {
//                await WriteEntityToConsoleAsync(item, $"{index} - \n");
//                index++;
//            }

//            return items;
//        }

//        public async Task<TEntity?> UpdateAsync()
//        {
//            if (!await repository.AnyAsync())
//            {
//                Console.WriteLine($"There are no {EntityNamePlural} available to update.\n");
//                return null;
//            }

//            Console.WriteLine($"You are now updating one of the {EntityNamePlural}.\n");

//            var items = await ReadAsync();

//            Console.WriteLine();

//            Console.WriteLine($"Please choose the {EntityName} you want to update.\n");

//            var choice = GetChoiceFromData(items);
//            var itemToUpdate = await GetUpdateEntityFromUser(items.ElementAt(choice - 1));

//            repository.Update(itemToUpdate);

//            return itemToUpdate;
//        }

//        public async Task DeleteAsync()
//        {
//            if (!await repository.AnyAsync())
//            {
//                Console.WriteLine($"There are no {EntityNamePlural} available to delete.\n");
//                return;
//            }

//            Console.WriteLine($"You are now deleting one of the {EntityNamePlural}.\n");

//            var items = await ReadAsync();

//            Console.WriteLine();

//            Console.WriteLine($"Please choose the {EntityName} you want to update.\n");

//            var choice = GetChoiceFromData(items);
//            var itemToDelete = items.ElementAt(choice - 1);

//            repository.Remove(itemToDelete);
//        }

//        public int GetChoiceFromData(IEnumerable<TEntity> items)
//        {
//            var correctChoiceMade = true;
//            var numberOfItems = items.Count();

//            while (true)
//            {
//                if (!correctChoiceMade)
//                {
//                    Console.WriteLine("You made an incorrect choice. Please provide one of the options and hit enter.\n");
//                }

//                Console.Write($"Your choice (1-{numberOfItems}): ");

//                var integerChoiceMade = int.TryParse(Console.ReadLine(), out int choice);

//                Console.WriteLine();

//                if (integerChoiceMade && choice >= 1 && choice <= numberOfItems)
//                {
//                    return choice;
//                }
//                else
//                {
//                    correctChoiceMade = false;
//                }
//            }
//        }

//        protected string GetChoice()
//        {
//            Console.WriteLine("Please choose which operation you want to execute.");
//            Console.WriteLine($"{CreateChoice} - Create");
//            Console.WriteLine($"{ReadChoice} - Read");
//            Console.WriteLine($"{UpdateChoice} - Update");
//            Console.WriteLine($"{DeleteChoice} - Delete");
//            Console.WriteLine($"{ExitChoice} - Exit");

//            Console.WriteLine();

//            if (!CorrectChoiceMade)
//            {
//                Console.WriteLine("You previously made an incorrect choice. Please provide one of the options and hit enter.\n");
//            }

//            Console.Write("Your choice (1-5): ");

//            var result = Console.ReadLine() ?? string.Empty;

//            Console.WriteLine();

//            return result;
//        }

//        protected void ReturnToManagerHomeScreen()
//        {
//            Console.WriteLine("Please hit enter to return to the manager home screen.");

//            Console.ReadLine();

//            Console.Clear();

//            ResetChoiceMade();
//        }

//        protected void ReturnToHomeScreen()
//        {
//            Console.WriteLine("Please hit enter to close the manager and return to the home screen.");

//            Console.ReadLine();

//            Console.Clear();
//        }

//        protected void Exit()
//        {
//            Console.WriteLine("Closing the manager and returning back to the home screen. Thank you!");
//        }

//        protected abstract Task<TEntity?> GetCreateEntityFromUser();

//        protected abstract Task<TEntity> GetUpdateEntityFromUser(TEntity entity);

//        public abstract Task WriteEntityToConsoleAsync(TEntity entity, string? prefix = null);
//    }
//}

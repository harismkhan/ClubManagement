

using ClubManagement.TestApp.Interfaces;

namespace ClubManagement.TestApp
{
    public class ClubManagementApplicationService : ChoiceSystemBase, IPlayerManagerService
    {
        private const string ClubChoice = "1";
        private const string PlayerChoice = "2";
        private const string CoachChoice = "3";
        private const string PitchChoice = "4";
        private const string TeamChoice = "5";
        private const string ExitChoice = "6";


        private readonly IClubManagerService clubManagerService;
        private readonly ITeamManagerService teamManagerService;
        private readonly IPitchManagerService pitchManagerService;
        private readonly ICoachManagerService coachManagerService;
        private readonly IPlayerManagerService playerManagerService;


        public ClubManagementApplicationService(IClubManagerService clubManagerService,
            ITeamManagerService teamManagerService,
            IPlayerManagerService playerManagerService,
            IPitchManagerService pitchManagerService,
            ICoachManagerService coachManagerService)
        {
            this.clubManagerService = clubManagerService;
            this.teamManagerService = teamManagerService;
            this.pitchManagerService = pitchManagerService;
            this.coachManagerService = coachManagerService;
            this.playerManagerService = playerManagerService;

        }

        public async Task RunAsync()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Welcome to the Club Manageent application\n");

                Console.WriteLine("Please choose which part of the application you want to manage.\n");
                Console.WriteLine($"{ClubChoice} - Clubs");
                Console.WriteLine($"{TeamChoice} - Teams");
                Console.WriteLine($"{PitchChoice} - Pitches");
                Console.WriteLine($"{CoachChoice} - Coaches");
                Console.WriteLine($"{ExitChoice} - Exit\n");

                if (!CorrectChoiceMade)
                {
                    Console.WriteLine("You previously made an incorrect choice. Please provide one of the options and hit enter.\n");
                }

                Console.Write("Your choice (1-5): ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case ClubChoice:
                        await clubManagerService.RunAsync();
                        ResetChoiceMade();
                        break;
                    case TeamChoice:
                        await teamManagerService.RunAsync();
                        ResetChoiceMade();
                        break;
                    case PitchChoice:
                        await pitchManagerService.RunAsync();
                        ResetChoiceMade();
                        break;
                    case CoachChoice:
                        await coachManagerService.RunAsync();
                        ResetChoiceMade();
                        break;
                    case PlayerChoice:
                        await playerManagerService.RunAsync();
                        ResetChoiceMade();
                        break;
                    case ExitChoice:
                        Console.WriteLine("Closing the application. Thank you!");
                        return;
                    default:
                        ChoiceMadeIncorrectly();
                        break;
                }
            }
        }
    }
}

using ClubManagement.TestApp;
using ClubManagement.TestApp.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClubManagementApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddClubManagementApplication(this IServiceCollection services)
        {
            services.AddScoped<IClubManagerService, ClubManagerService>();
            services.AddScoped<ICoachManagerService, CoachManagerService>();
            services.AddScoped<IPlayerManagerService, PlayerManagerService>();
            services.AddScoped<ITeamManagerService, TeamManagerService>();
            services.AddScoped<IPitchManagerService, PitchManagerService>();

            return services;
        }
    }
}

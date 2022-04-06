using ClubManagement.Services;
using ClubManagement.Services.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPitchService, PitchService>();

            return services;
        }
    }
}

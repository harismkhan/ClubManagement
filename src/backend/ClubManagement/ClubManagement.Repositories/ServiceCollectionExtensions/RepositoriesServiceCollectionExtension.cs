using ClubManagement.Repositories.Interfaces;
using ClubManagement.Repositories.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPitchRepository, PitchRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}

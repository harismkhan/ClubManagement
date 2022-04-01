using ClubManagement.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClubManagementContext>(options => options.UseSqlServer(configuration.GetConnectionString("default")));

            return services;
        }
    }
}

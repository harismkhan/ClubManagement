using ClubManagement.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClubManagement.Database.Migrator
{
    public static class AutomaticMigrationExtension
    {
        public static IHost ApplyMigrations(this IHost host)
        {
            var clubManagementContext = host.Services.GetRequiredService<ClubManagementContext>();
            if (clubManagementContext.Database.GetPendingMigrations().Any())
            {
                clubManagementContext.Database.Migrate();
            }

            return host;
        }
    }
}

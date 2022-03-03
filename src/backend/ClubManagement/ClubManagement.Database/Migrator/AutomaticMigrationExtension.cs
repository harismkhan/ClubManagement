using isolutions.EntityFramework.Code.First.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace isolutions.EntityFramework.Code.First.Database.Migrator
{
    public static class AutomaticMigrationExtension
    {
        public static IHost ApplyMigrations(this IHost host)
        {
            var flightBookingContext = host.Services.GetRequiredService<FlightBookingContext>();
            if (flightBookingContext.Database.GetPendingMigrations().Any())
            {
                flightBookingContext.Database.Migrate();
            }

            return host;
        }
    }
}

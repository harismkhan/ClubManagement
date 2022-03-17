﻿using ClubManagement.Database.Migrator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ClubManagement.TestApp
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var startup = new Startup(configuration);

            var builder = Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(services => startup.ConfigureServices(services));

            var app = builder.Build();

            app.ApplyMigrations();

        }

    }

}

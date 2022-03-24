using ClubManagement.Repositories.Interfaces;
using ClubManagement.Repositories.Repositories;
using ClubManagement.Services;
using ClubManagement.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args); 
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

ConfigureService(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureService(IServiceCollection services)
{
    services.AddDatabase(configuration);

    services.AddScoped<IClubRepository, ClubRepository>();
    services.AddScoped<IPlayerRepository, PlayerRepository>();
    services.AddScoped<IPitchRepository, PitchRepository>();
    services.AddScoped<ITeamRepository, TeamRepository>();
    services.AddScoped<ICoachRepository, CoachRepository>();

    services.AddScoped<IClubService, ClubService>();
}
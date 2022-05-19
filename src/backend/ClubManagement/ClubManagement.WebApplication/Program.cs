using ClubManagement.Repositories.Interfaces;
using ClubManagement.Repositories.Repositories;
using ClubManagement.Services;
using ClubManagement.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
ConfigureServices(builder.Services);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}
app.UseCors(builder =>
{
builder.WithOrigins("http://127.0.0.1:5500")
.AllowAnyMethod()
.AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
void ConfigureServices(IServiceCollection services)
{
    services.AddDatabase(configuration);
    services.AddRepositories();
    services.AddServices();

    services.AddScoped<IClubRepository, ClubRepository>();
    services.AddScoped<ITeamRepository, TeamRepository>();
    services.AddScoped<ICoachRepository, CoachRepository>();
    services.AddScoped<IPlayerRepository, PlayerRepository>();
    services.AddScoped<IPitchRepository, PitchRepository>();

    services.AddScoped<IClubService, ClubService>();
    services.AddScoped<ITeamService, TeamService>();
    services.AddScoped<ICoachService, CoachService>();
    services.AddScoped<IPlayerService, PlayerService>();
    services.AddScoped<IPitchService, PitchService>();
}


using ClubManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace isolutions.EntityFramework.Code.First.Database.Contexts
{
    public class ClubManagementContext : DbContext
    {
        public ClubManagementContext(DbContextOptions<ClubManagementContext> options) : base(options)
        {
            Clubs = Set<Club>();
            Teams = Set<Team>();
            Members = Set<Member>();
            Coaches = Set<Coach>();
            Players = Set<Player>();   
            Pitches = Set<Pitch>();
        }

        public DbSet<Club> Clubs { get; }
        public DbSet<Team> Teams { get; }
        public DbSet<Member> Members { get; }
        public DbSet<Coach> Coaches { get; }
        public DbSet<Player> Players { get; }
        public DbSet<Pitch> Pitches { get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureClub(modelBuilder.Entity<Club>());
            ConfigureTeam(modelBuilder.Entity<Team>());
            ConfigureMember(modelBuilder.Entity<Member>());
            ConfigureCoach(modelBuilder.Entity<Coach>());
            ConfigurePlayer(modelBuilder.Entity<Player>());
            ConfigurePitch(modelBuilder.Entity<Pitch>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLazyLoadingProxies();

        private void ConfigureClub(EntityTypeBuilder<Club> builder)
        {
            builder
                .ToTable(nameof(Club) + "s");
            builder
                .Property(club => club.City)
                .HasMaxLength(Size.StringMediumSize);
            builder
               .Property(club => club.Name)
               .HasMaxLength(Size.StringMediumSize);
            builder
               .Property(club => club.Street)
               .HasMaxLength(Size.StringMediumSize);
            builder
               .Property(club => club.Zip)
               .HasMaxLength(Size.StringMediumSize);
            builder
                .HasMany(club => club.Member)
                .HasForeignKey(club => club.Member.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureTeam(EntityTypeBuilder<Member> builder)
        {
            builder
                .ToTable(nameof(Member) + "s");
            builder
               .Property(member => member.FirstName)
               .HasMaxLength(Size.StringMediumSize);
            builder
               .Property(member => member.LastName)
               .HasMaxLength(Size.StringMediumSize);
            builder
               .Property(member => member.BirthDate)
               .HasMaxLength(Size.StringMediumSize);
            builder
               .Property(member => member.Street)
               .HasMaxLength(Size.StringMediumSize);
            builder
               .Property(member => member.City)
               .HasMaxLength(Size.StringMediumSize);
            builder
               .Property(member => member.Zip)
               .HasMaxLength(Size.StringMediumSize);
            builder
               .HasOne(member => member.Club)
               .WithMany(club => club.Members)
               .HasForeignKey(member => member.ClubId)
               .OnDelete(DeleteBehavior.Cascade);
            builder
               .Property(member => member.Team)
               .HasMaxLength(Size.StringMediumSize);
            builder
                .HasMany(member => member.Player)
                .HasForeignKey(member => member.Player.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(member => member.Coach)
                .HasForeignKey(member => member.Coach.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureMember(EntityTypeBuilder<Team> builder)
        {
            builder
                .ToTable(nameof(Team) + "s");
            builder
                .HasOne(booking => booking.Flight)
                .WithMany(flight => flight.Bookings)
                .HasForeignKey(booking => booking.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(booking => booking.Customer)
                .WithMany(customer => customer.Bookings)
                .HasForeignKey(booking => booking.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureCoach(EntityTypeBuilder<Coach> builder)
        {
            builder
                .ToTable(nameof(Coach) + "es");
            builder
                .Property(customer => customer.FirstName)
                .HasMaxLength(Size.StringMediumSmallSize);
            builder
                .Property(customer => customer.LastName)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(customer => customer.Email)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .OwnsOne(customer => customer.Address, navBuilder =>
                {
                    navBuilder
                        .Property(address => address.Street)
                        .HasMaxLength(Size.StringMediumSize);
                    navBuilder
                        .Property(address => address.City)
                        .HasMaxLength(Size.StringMediumSmallSize);
                });
        }

        private void ConfigurePlayer(EntityTypeBuilder<Player> builder)
        {
            builder
                .ToTable(nameof(Player) + "s");
            builder
                .HasOne(flight => flight.Origin)
                .WithMany(airport => airport.FlightsAsOrigin)
                .HasForeignKey(flight => flight.OriginId)
                .OnDelete(DeleteBehavior.ClientCascade);
            builder
                .HasOne(flight => flight.Destination)
                .WithMany(airport => airport.FlightsAsDestination)
                .HasForeignKey(flight => flight.DestinationId)
                .OnDelete(DeleteBehavior.ClientCascade);
            builder
                .HasAlternateKey(flight => new { flight.OriginId, flight.DestinationId });
        }

        private void ConfigurePitch(EntityTypeBuilder<Pitch> builder)
        {
            builder
                .ToTable(nameof(Pitch) + "es");
            builder
                .HasOne(booking => booking.Flight)
                .WithMany(flight => flight.Bookings)
                .HasForeignKey(booking => booking.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(booking => booking.Customer)
                .WithMany(customer => customer.Bookings)
                .HasForeignKey(booking => booking.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

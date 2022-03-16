using ClubManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubManagement.Domain.Models.Constants;

namespace ClubManagement.Contexts
{
    public class ClubManagementContext : DbContext
    {
        public ClubManagementContext(DbContextOptions<ClubManagementContext> options) : base(options)
        {
            Clubs = Set<Club>();
            Teams = Set<Team>();
            Coaches = Set<Coach>();
            Players = Set<Player>();   
            Pitches = Set<Pitch>();
        }

        public DbSet<Club> Clubs { get; }
        public DbSet<Team> Teams { get; }
        public DbSet<Coach> Coaches { get; }
        public DbSet<Player> Players { get; }
        public DbSet<Pitch> Pitches { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureClub(modelBuilder.Entity<Club>());
            ConfigureTeam(modelBuilder.Entity<Team>());
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
                .Property(club => club.Name)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(club => club.Street)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(club => club.City)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(club => club.Zip)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .HasMany(club => club.Coaches)
                .WithOne(coach => coach.Club);
            builder
                .HasMany(club => club.Pitches)
                .WithOne(pitch => pitch.Club);
            builder
                .HasMany(club => club.Players)
                .WithOne(player => player.Club);
            builder
                .HasMany(club => club.Teams)
                .WithOne(team => team.Club);
        }

        private void ConfigureTeam(EntityTypeBuilder<Team> builder)
        {
            builder
                .ToTable(nameof(Team) + "s");
            builder
                .HasOne(team => team.Club)
                .WithMany(club => club.Teams)
                .HasForeignKey(team => team.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(club => club.Players)
                .WithOne(player => player.Team);
            builder
                .HasMany(club => club.Coaches)
                .WithOne(coach => coach.Team);
        }

        private void ConfigureCoach(EntityTypeBuilder<Coach> builder)
        {
            builder
                .ToTable(nameof(Coach) + "es");
            builder
                .Property(coach => coach.FirstName)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(coach => coach.LastName)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(coach => coach.Street)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(coach => coach.City)
                .HasMaxLength(Size.StringSmallSize);
            builder
                .Property(coach => coach.Zip)
                .HasMaxLength(Size.StringVerySmallSize);
            builder
                .HasOne(coach => coach.Club)
                .WithMany(club => club.Coaches)
                .HasForeignKey(coach => coach.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(coach => coach.Team)
                .WithMany(team => team.Coaches)
                .HasForeignKey(coach => coach.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        private void ConfigurePlayer(EntityTypeBuilder<Player> builder)
        {
            builder
                .ToTable(nameof(Player) + "s");
            builder
                .Property(player => player.FirstName)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(player => player.LastName)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(player => player.Street)
                .HasMaxLength(Size.StringMediumSize);
            builder
                .Property(player => player.City)
                .HasMaxLength(Size.StringSmallSize);
            builder
                .Property(player => player.Zip)
                .HasMaxLength(Size.StringVerySmallSize);
            builder
                .HasOne(player => player.Club)
                .WithMany(club => club.Players)
                .HasForeignKey(player => player.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(player => player.Team)
                .WithMany(team => team.Players)
                .HasForeignKey(player => player.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigurePitch(EntityTypeBuilder<Pitch> builder)
        {
            builder
                .ToTable(nameof(Pitch) + "es");
            builder
                .Property(pitch => pitch.Street)
                .HasMaxLength(Size.StringMediumSmallSize);
            builder
                .Property(pitch => pitch.City)
                .HasMaxLength(Size.StringSmallSize);
            builder
                .Property(pitch => pitch.Zip)
                .HasMaxLength(Size.StringVerySmallSize);
            builder
                .HasOne(pitch => pitch.Club)
                .WithMany(club => club.Pitches)
                .HasForeignKey(pitch => pitch.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

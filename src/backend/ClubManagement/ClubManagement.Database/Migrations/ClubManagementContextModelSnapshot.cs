using ClubManagement.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace ClubManagement.Database.Migrations
{
    [DbContext(typeof(ClubManagementContext))]
    partial class ClubManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClubManagement.Domain.Club", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Clubs", (string)null);
                });

            modelBuilder.Entity("ClubManagement.Domain.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("TeamId");

                    b.ToTable("Coaches", (string)null);
                });

            modelBuilder.Entity("ClubManagement.Domain.Pitch", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Pitches", (string)null);
                });

            modelBuilder.Entity("ClubManagement.Domain.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PlayerNumber")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("ClubManagement.Domain.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("ClubManagement.Domain.Coach", b =>
                {
                    b.HasOne("ClubManagement.Domain.Club", "Club")
                        .WithMany("Coaches")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClubManagement.Domain.Team", "Team")
                        .WithMany("Coaches")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Club");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ClubManagement.Domain.Pitch", b =>
                {
                    b.HasOne("ClubManagement.Domain.Club", "Club")
                        .WithMany("Pitches")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Club");
                });

            modelBuilder.Entity("ClubManagement.Domain.Player", b =>
                {
                    b.HasOne("ClubManagement.Domain.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClubManagement.Domain.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Club");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ClubManagement.Domain.Team", b =>
                {
                    b.HasOne("ClubManagement.Domain.Club", "Club")
                        .WithMany("Teams")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Club");
                });

            modelBuilder.Entity("ClubManagement.Domain.Club", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Pitches");

                    b.Navigation("Players");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("ClubManagement.Domain.Team", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}

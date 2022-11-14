﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(FMContext))]
    partial class FMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Game", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfViewers")
                        .HasColumnType("int");

                    b.Property<Guid>("OpponentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ResultOfTheGame")
                        .HasColumnType("int");

                    b.Property<Guid>("StadiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GameId");

                    b.HasIndex("OpponentsId");

                    b.HasIndex("StadiumId");

                    b.HasIndex("TeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HealthStatus")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DAL.Models.Stadium", b =>
                {
                    b.Property<Guid>("StadiumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerSeat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StadiumName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StadiumId");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("DAL.Models.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DAL.Models.Game", b =>
                {
                    b.HasOne("DAL.Models.Team", "Opponents")
                        .WithMany("Games")
                        .HasForeignKey("OpponentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Stadium", "Stadium")
                        .WithMany("Games")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Opponents");

                    b.Navigation("Stadium");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.HasOne("DAL.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("DAL.Models.Stadium", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("DAL.Models.Team", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
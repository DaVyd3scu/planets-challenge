﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(PlanetsChallengeDbContext))]
    [Migration("20221031020834_solar_system_pk")]
    partial class solar_system_pk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("api.Models.Captain", b =>
                {
                    b.Property<int>("CaptainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaptainId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CaptainId");

                    b.ToTable("Captains");
                });

            modelBuilder.Entity("api.Models.Planet", b =>
                {
                    b.Property<int>("PlanetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanetId"), 1L, 1);

                    b.Property<int?>("CaptainId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SolarSystemId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Can only have the following values: OK, !OK, TODO, En Route");

                    b.HasKey("PlanetId");

                    b.HasIndex("CaptainId");

                    b.HasIndex("SolarSystemId");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("api.Models.Robot", b =>
                {
                    b.Property<int>("RobotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RobotId"), 1L, 1);

                    b.Property<int?>("CaptainId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RobotId");

                    b.HasIndex("CaptainId");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("api.Models.SolarSystem", b =>
                {
                    b.Property<int>("SolarSystemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolarSystemId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SolarSystemId");

                    b.ToTable("SolarSystems");
                });

            modelBuilder.Entity("api.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.Property<int>("RobotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.HasIndex("RobotId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("api.Models.Planet", b =>
                {
                    b.HasOne("api.Models.Captain", "Captain")
                        .WithMany("Planets")
                        .HasForeignKey("CaptainId");

                    b.HasOne("api.Models.SolarSystem", "SolarSystem")
                        .WithMany("Planets")
                        .HasForeignKey("SolarSystemId");

                    b.Navigation("Captain");

                    b.Navigation("SolarSystem");
                });

            modelBuilder.Entity("api.Models.Robot", b =>
                {
                    b.HasOne("api.Models.Captain", "Captain")
                        .WithMany("Robots")
                        .HasForeignKey("CaptainId");

                    b.Navigation("Captain");
                });

            modelBuilder.Entity("api.Models.Visit", b =>
                {
                    b.HasOne("api.Models.Planet", "Planet")
                        .WithMany("Visits")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Robot", "Robot")
                        .WithMany("Visits")
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");

                    b.Navigation("Robot");
                });

            modelBuilder.Entity("api.Models.Captain", b =>
                {
                    b.Navigation("Planets");

                    b.Navigation("Robots");
                });

            modelBuilder.Entity("api.Models.Planet", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("api.Models.Robot", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("api.Models.SolarSystem", b =>
                {
                    b.Navigation("Planets");
                });
#pragma warning restore 612, 618
        }
    }
}
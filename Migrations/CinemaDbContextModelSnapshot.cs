﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgettoCinema.DbMiddleware;

namespace ProgettoCinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProgettoCinema.Domain.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.CinemaRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CinemaId");

                    b.HasIndex("MovieId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TicketId")
                        .IsUnique()
                        .HasFilter("[TicketId] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoomId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.CinemaRoom", b =>
                {
                    b.HasOne("ProgettoCinema.Domain.Cinema", "Cinema")
                        .WithMany("Rooms")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgettoCinema.Domain.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Customer", b =>
                {
                    b.HasOne("ProgettoCinema.Domain.Ticket", "Ticket")
                        .WithOne("Customer")
                        .HasForeignKey("ProgettoCinema.Domain.Customer", "TicketId");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Ticket", b =>
                {
                    b.HasOne("ProgettoCinema.Domain.CinemaRoom", "Room")
                        .WithMany("OccupiedSeats")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Cinema", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.CinemaRoom", b =>
                {
                    b.Navigation("OccupiedSeats");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Ticket", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

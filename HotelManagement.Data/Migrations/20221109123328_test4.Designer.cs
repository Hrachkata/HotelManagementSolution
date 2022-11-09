﻿// <auto-generated />
using System;
using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221109123328_test4")]
    partial class test4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5191),
                            Description = "Some Department",
                            IsActive = true,
                            Name = "F&B"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5209),
                            Description = "This is the human resource department with access to employee management and hiring new employees.",
                            IsActive = true,
                            Name = "Human Resources"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5212),
                            Description = "This is the IT department with access to employee management, hiring new employees, admin panel and front desk.",
                            IsActive = true,
                            Name = "IT department"
                        },
                        new
                        {
                            Id = 4,
                            CreatedOn = new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5215),
                            Description = "This is the front desk/reception department with access to reservations and front desk.",
                            IsActive = true,
                            Name = "Reservations"
                        },
                        new
                        {
                            Id = 5,
                            CreatedOn = new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5217),
                            Description = "This is the director department with access to employee management, hiring new employees, admin panel and front desk.",
                            IsActive = true,
                            Name = "Director"
                        },
                        new
                        {
                            Id = 6,
                            CreatedOn = new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5265),
                            Description = "This is full access! NOT RECOMMENDED",
                            IsActive = true,
                            Name = "Owner"
                        });
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.EmployeeDepartment", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("EmployeesDepartments");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuestEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestNationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("LateDeparture")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.RoleDepartment", b =>
                {
                    b.Property<int>("RoleNameId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("RoleNameId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("RolesDepartments");

                    b.HasData(
                        new
                        {
                            RoleNameId = 1,
                            DepartmentId = 1
                        },
                        new
                        {
                            RoleNameId = 2,
                            DepartmentId = 2
                        },
                        new
                        {
                            RoleNameId = 3,
                            DepartmentId = 3
                        },
                        new
                        {
                            RoleNameId = 2,
                            DepartmentId = 3
                        },
                        new
                        {
                            RoleNameId = 6,
                            DepartmentId = 3
                        },
                        new
                        {
                            RoleNameId = 6,
                            DepartmentId = 4
                        },
                        new
                        {
                            RoleNameId = 3,
                            DepartmentId = 5
                        },
                        new
                        {
                            RoleNameId = 2,
                            DepartmentId = 5
                        },
                        new
                        {
                            RoleNameId = 5,
                            DepartmentId = 5
                        },
                        new
                        {
                            RoleNameId = 1,
                            DepartmentId = 6
                        },
                        new
                        {
                            RoleNameId = 2,
                            DepartmentId = 6
                        },
                        new
                        {
                            RoleNameId = 3,
                            DepartmentId = 6
                        },
                        new
                        {
                            RoleNameId = 4,
                            DepartmentId = 6
                        },
                        new
                        {
                            RoleNameId = 5,
                            DepartmentId = 6
                        },
                        new
                        {
                            RoleNameId = 6,
                            DepartmentId = 6
                        });
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.RoleName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameOfRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleName");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameOfRole = "F&B"
                        },
                        new
                        {
                            Id = 2,
                            NameOfRole = "HUMAN RESOURCES"
                        },
                        new
                        {
                            Id = 3,
                            NameOfRole = "ADMIN"
                        },
                        new
                        {
                            Id = 4,
                            NameOfRole = "DIRECTOR"
                        },
                        new
                        {
                            Id = 5,
                            NameOfRole = "OWNER"
                        },
                        new
                        {
                            Id = 6,
                            NameOfRole = "FRONT DESK"
                        });
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("FloorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCleaned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOutOfService")
                        .HasColumnType("bit");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.UserModels.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EGN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RFID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("be78793b-260f-435e-bc1a-91cd6c39b7c5"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "084da9c4-7a80-4eba-bb3a-6a7e666b42d9",
                            CreatedOn = new DateTime(2022, 11, 9, 14, 33, 28, 115, DateTimeKind.Local).AddTicks(5683),
                            EGN = "123",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            IsActive = true,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            MiddleName = "Admin",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEFr5AqvPiGwaAVH0MrpbwdARBvXk+iZm3JoC8kkvTAI+Hw4TwIBbHT0beNheeexAJQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            RFID = "123456789",
                            Salary = 0m,
                            SecurityStamp = "2d5f8b4c-2c61-4972-9766-29f57eef592a",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("HotelManagement.Data.Models.UserModels.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e17d0ad3-e193-43e2-a013-85f58c6fc037"),
                            ConcurrencyStamp = "63ca2c04-11cf-418d-a56e-28a03dc29e6a",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("865f129d-81a1-4109-91d1-6a448a16bf04"),
                            ConcurrencyStamp = "a7d07c24-ee4b-49d9-bcf4-c6addaf9d817",
                            Name = "f&b",
                            NormalizedName = "F&B"
                        },
                        new
                        {
                            Id = new Guid("547fd860-99d3-4f19-ad8f-824ee837941d"),
                            ConcurrencyStamp = "649a73ee-0b38-4fd4-a956-adbf0cdf7139",
                            Name = "Human Resources",
                            NormalizedName = "HUMAN RESOURCES"
                        },
                        new
                        {
                            Id = new Guid("365bf314-9750-4a29-b676-20545aea6d21"),
                            ConcurrencyStamp = "a4953987-955b-4762-a84c-ce31abfb17af",
                            Name = "Director",
                            NormalizedName = "DIRECTOR"
                        },
                        new
                        {
                            Id = new Guid("8e3f7bb5-23c9-4edf-90a1-fb7df35bd9b6"),
                            ConcurrencyStamp = "20eb8503-3dc1-4dc6-989f-4dc96479ead2",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = new Guid("3b6d48ea-0f56-4dee-bc00-7e4489cd1d51"),
                            ConcurrencyStamp = "b4b648dd-de75-4887-ab5b-3b6bd7d5ee42",
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        },
                        new
                        {
                            Id = new Guid("ab08c546-b7a7-4c31-9417-526f542c3812"),
                            ConcurrencyStamp = "8c2b7eb1-6223-4110-841b-53320d383838",
                            Name = "Front Desk",
                            NormalizedName = "FRONT DESK"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("be78793b-260f-435e-bc1a-91cd6c39b7c5"),
                            RoleId = new Guid("3b6d48ea-0f56-4dee-bc00-7e4489cd1d51")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.EmployeeDepartment", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.UserModels.ApplicationUser", "ApplicationUser")
                        .WithMany("EmployeeDepartment")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement.Data.Models.Models.Department", "Department")
                        .WithMany("EmployeeDepartment")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Reservation", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.RoleDepartment", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.Models.Department", "Department")
                        .WithMany("RoleDepartment")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement.Data.Models.Models.RoleName", "RoleName")
                        .WithMany("RoleDepartment")
                        .HasForeignKey("RoleNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("RoleName");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Room", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.Models.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement.Data.Models.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.UserModels.ApplicationUserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.UserModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.UserModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.UserModels.ApplicationUserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement.Data.Models.UserModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("HotelManagement.Data.Models.UserModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Department", b =>
                {
                    b.Navigation("EmployeeDepartment");

                    b.Navigation("RoleDepartment");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Floor", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.RoleName", b =>
                {
                    b.Navigation("RoleDepartment");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.Room", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelManagement.Data.Models.UserModels.ApplicationUser", b =>
                {
                    b.Navigation("EmployeeDepartment");
                });
#pragma warning restore 612, 618
        }
    }
}

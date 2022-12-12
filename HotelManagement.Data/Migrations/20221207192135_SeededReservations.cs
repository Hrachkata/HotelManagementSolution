﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class SeededReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    EGN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfRole = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerPerson = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesDepartments",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesDepartments", x => new { x.ApplicationUserId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_EmployeesDepartments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesDepartments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoleNameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesDepartments", x => new { x.RoleNameId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_RolesDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesDepartments_RoleName_RoleNameId",
                        column: x => x.RoleNameId,
                        principalTable: "RoleName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    IsCleaned = table.Column<bool>(type: "bit", nullable: false),
                    IsOutOfService = table.Column<bool>(type: "bit", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GuestFirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GuestLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GuestNationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GuestPhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GuestEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedIn = table.Column<bool>(type: "bit", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("03c7e9c8-991e-4cf5-b1dd-b89c8a0354f2"), "14042f4a-6d1c-4a66-be4e-eae60dc3a38f", "Front Desk", "FRONT DESK" },
                    { new Guid("08a5b7ee-10d8-4370-b08c-11e0c53563b0"), "8903752e-3e02-40e3-92f7-fe2aec052d9e", "Admin", "ADMIN" },
                    { new Guid("2da8c9bc-a563-4890-b6f6-f6466be822ad"), "3760389f-5722-4351-88ec-576c8ac3d3ec", "Owner", "OWNER" },
                    { new Guid("661824fc-5d6b-4348-914c-f9f2e1f30391"), "41637b26-7e52-4c64-a47f-76c5a3e6e440", "f&b", "F&B" },
                    { new Guid("d39021a4-ee63-46d6-a007-e76da5362392"), "0cf8b9cd-fbe1-4e1d-955d-77894fa7b07d", "Manager", "MANAGER" },
                    { new Guid("ea172e7f-ff07-49d0-976d-5f9e2b955da4"), "79152ae1-59cb-460c-84e6-136051b3cbad", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("f7ff6da8-0a7e-4c97-9554-8e5f006a8c4e"), "ae4d85ff-f699-4753-93ab-4ab468fdc16e", "Director", "DIRECTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0902201d-e2b8-4f3f-a165-cecf6df5cafe"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1a1ceba6-4bba-4392-90a8-93b2254be0e4", new DateTime(2022, 12, 7, 21, 21, 35, 389, DateTimeKind.Local).AddTicks(9041), null, "2934827162", null, null, true, "Johnny", true, "Johnathan", true, null, "Doe", null, "JOHN", "AQAAAAEAACcQAAAAENiMnXDru3FgaYajCt7GwnjDzIa3JshcYGNgXHlcNHLSN8dh8/ZubazrfKwYMYRK+A==", "08923471624", false, "324123539", 9000m, "7a3ffad7-a474-44e7-991e-650a109b5581", false, "John" },
                    { new Guid("2930464c-c435-40f4-a381-0bef0423f857"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8dab0342-44fe-4563-b924-5616f0ba8950", new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(5580), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEEk/lzt9IaacJqistG8cYBBGiJbf89NXPmIA0UD9ynmrW6eh5FDMwrl6ImRYw2wR9g==", "1234567890", false, "123456789", 0m, "04d93764-fb8a-43ca-8cd8-12d97e2477ee", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "EditedOn", "EmployeeCount", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4797), null, "Some Department", null, null, true, "F&B" },
                    { 2, new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4844), null, "This is the human resource department with access to employee management and hiring new employees.", null, null, true, "Human Resources" },
                    { 3, new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4848), null, "This is the IT department with access to employee management, hiring new employees, admin panel and front desk.", null, null, true, "IT department" },
                    { 4, new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4852), null, "This is the front desk/reception department with access to reservations and front desk.", null, null, true, "Reservations" },
                    { 5, new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4856), null, "This is the director department with access to employee management, hiring new employees, admin panel and front desk.", null, null, true, "Director" },
                    { 6, new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4924), null, "This is full access! NOT RECOMMENDED", null, null, true, "Owner" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "EditedOn", "FloorNumber", "IsActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true },
                    { 2, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true },
                    { 3, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true },
                    { 4, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true }
                });

            migrationBuilder.InsertData(
                table: "RoleName",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "EditedOn", "IsActive", "NameOfRole" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "F&B" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "HUMAN RESOURCES" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "ADMIN" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "DIRECTOR" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "OWNER" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "FRONT DESK" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "EditedOn", "IsActive", "PricePerPerson", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 100m, "Standard" },
                    { 2, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 150m, "Apartment" },
                    { 3, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 250m, "Deluxe" },
                    { 4, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 400m, "President" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2da8c9bc-a563-4890-b6f6-f6466be822ad"), new Guid("2930464c-c435-40f4-a381-0bef0423f857") });

            migrationBuilder.InsertData(
                table: "RolesDepartments",
                columns: new[] { "DepartmentId", "RoleNameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 3, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 6, 4 },
                    { 5, 5 },
                    { 6, 5 },
                    { 3, 6 },
                    { 4, 6 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "CreatedOn", "DeletedOn", "EditedOn", "FloorId", "IsActive", "IsCleaned", "IsOccupied", "IsOutOfService", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 101, 1 },
                    { 2, 4, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 102, 2 },
                    { 3, 4, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 103, 2 },
                    { 4, 4, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 104, 1 },
                    { 5, 3, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 105, 1 },
                    { 6, 3, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, false, false, true, 106, 1 },
                    { 7, 3, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, false, false, true, 107, 1 },
                    { 8, 2, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 201, 1 },
                    { 9, 1, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 202, 2 },
                    { 10, 4, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 203, 2 },
                    { 11, 1, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 204, 1 },
                    { 12, 1, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, false, false, false, 205, 1 },
                    { 13, 1, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, true, 205, 1 },
                    { 14, 2, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 301, 3 },
                    { 15, 1, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 302, 2 },
                    { 16, 4, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 303, 3 },
                    { 17, 4, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, false, false, false, 303, 3 },
                    { 18, 2, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true, true, false, false, 401, 4 },
                    { 19, 2, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true, true, false, false, 402, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Address", "ArrivalDate", "CheckedIn", "CreatedOn", "DeletedOn", "DepartureDate", "EditedOn", "GuestEmail", "GuestFirstName", "GuestLastName", "GuestNationality", "GuestPhoneNumber", "IsActive", "NumberOfChildren", "NumberOfGuests", "RoomId", "totalPrice" },
                values: new object[,]
                {
                    { "0a5b7675-4437-47e1-a614-6d58b6fda482", "Sofia 34 st. 2", new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "karakan@abv.bg", "Kapucin", "Krava", "Tigan", "4643453453352", true, 0, 2, 7, 3840m },
                    { "3b19b085-8df1-4157-95d7-3b0e2fc544fe", "Avenue 235 st. 2", new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), null, "bacro@abv.bg", "Alex", "Malex", "Bulgarian", "74572", true, 1, 5, 6, 3000m },
                    { "453b7f24-89a4-404e-91a0-67ef3ebe842c", "Berlinm st. 2", new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "aeiotawi@abv.bg", "Gorgon", "Maimun", "Etipiq", "432522342552", true, 1, 3, 4, 7000m },
                    { "993ecb0a-5618-4704-9ef3-3d0aeac37b4a", "Svishtov 532", new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), null, "gasgao@abv.bg", "Makaron", "Sharan", "Lujica", "247457452", true, 1, 2, 3, 1000m },
                    { "c5da5173-ec00-437a-bd07-7056c58ade1b", "Ararwaerawe st. 2", new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), null, "bachokiro@abv.bg", "Jogn", "Bonbon", "Ebnasdg", "43252352", true, 1, 2, 1, 300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RFID",
                table: "AspNetUsers",
                column: "RFID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesDepartments_DepartmentId",
                table: "EmployeesDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesDepartments_DepartmentId",
                table: "RolesDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmployeesDepartments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RolesDepartments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "RoleName");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}

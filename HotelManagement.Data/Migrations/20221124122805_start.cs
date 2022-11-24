using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class start : Migration
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
                    RFID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EGN = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    NameOfRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestNationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuestEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LateDeparture = table.Column<bool>(type: "bit", nullable: true),
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
                    { new Guid("069eb9f5-bdc2-4385-9c7a-656510224335"), "9f0e6327-3b77-4ad8-ae71-b3b527797286", "Front Desk", "FRONT DESK" },
                    { new Guid("1ab16739-72be-40af-b837-d8fc2e3ec64c"), "217f0993-2e24-40d4-a29d-cf52ea3379e3", "f&b", "F&B" },
                    { new Guid("29f53748-119d-4612-8f2a-4a8856b72358"), "099f4d62-e5d9-43ea-81b4-03f4a1ffdc4a", "Manager", "MANAGER" },
                    { new Guid("50447877-e7ec-47ac-a359-1549a28e9a50"), "8a07092d-e5de-4ea4-9c9d-11673d229243", "Admin", "ADMIN" },
                    { new Guid("9287d6a9-058a-4899-a6c8-9df710937898"), "08a8ca9d-02cc-4eaa-9203-0ccff878c5ae", "Director", "DIRECTOR" },
                    { new Guid("d64ba13a-a777-4447-abdf-bb2f7ab0a6c7"), "f8de93a4-af3e-44f5-a40b-7bf87b22f754", "Owner", "OWNER" },
                    { new Guid("de423304-f9e1-43aa-b3c5-4c5d00cc37b2"), "1ceba69c-b25d-46e1-8568-deddba3ab412", "Human Resources", "HUMAN RESOURCES" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4402ac12-698d-4d8d-94b8-d5c58c66de78"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6315eb20-87bf-42c5-97db-e4080b28cd78", new DateTime(2022, 11, 24, 14, 28, 5, 496, DateTimeKind.Local).AddTicks(1234), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEGAAynQl5norGFdhY+UBywIjSKJ6G6DVtRJFC8T4NNx7l7KLUwQpNO/KUY8Zwx/FXQ==", "1234567890", false, "123456789", 0m, "30e8f10f-98d4-4d0d-b2f3-b016154cedf9", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "EditedOn", "EmployeeCount", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 24, 14, 28, 5, 504, DateTimeKind.Local).AddTicks(976), null, "Some Department", null, null, true, "F&B" },
                    { 2, new DateTime(2022, 11, 24, 14, 28, 5, 504, DateTimeKind.Local).AddTicks(995), null, "This is the human resource department with access to employee management and hiring new employees.", null, null, true, "Human Resources" },
                    { 3, new DateTime(2022, 11, 24, 14, 28, 5, 504, DateTimeKind.Local).AddTicks(997), null, "This is the IT department with access to employee management, hiring new employees, admin panel and front desk.", null, null, true, "IT department" },
                    { 4, new DateTime(2022, 11, 24, 14, 28, 5, 504, DateTimeKind.Local).AddTicks(1000), null, "This is the front desk/reception department with access to reservations and front desk.", null, null, true, "Reservations" },
                    { 5, new DateTime(2022, 11, 24, 14, 28, 5, 504, DateTimeKind.Local).AddTicks(1002), null, "This is the director department with access to employee management, hiring new employees, admin panel and front desk.", null, null, true, "Director" },
                    { 6, new DateTime(2022, 11, 24, 14, 28, 5, 504, DateTimeKind.Local).AddTicks(1006), null, "This is full access! NOT RECOMMENDED", null, null, true, "Owner" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "EditedOn", "FloorNumber", "IsActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true },
                    { 2, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true },
                    { 3, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true },
                    { 4, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true }
                });

            migrationBuilder.InsertData(
                table: "RoleName",
                columns: new[] { "Id", "NameOfRole" },
                values: new object[,]
                {
                    { 1, "F&B" },
                    { 2, "HUMAN RESOURCES" },
                    { 3, "ADMIN" },
                    { 4, "DIRECTOR" },
                    { 5, "OWNER" },
                    { 6, "FRONT DESK" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "EditedOn", "IsActive", "PricePerPerson", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 100m, "Standard" },
                    { 2, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 150m, "Apartment" },
                    { 3, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 250m, "Deluxe" },
                    { 4, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 400m, "President" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d64ba13a-a777-4447-abdf-bb2f7ab0a6c7"), new Guid("4402ac12-698d-4d8d-94b8-d5c58c66de78") });

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
                    { 1, 3, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 101, 1 },
                    { 2, 4, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 102, 2 },
                    { 3, 4, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 103, 2 },
                    { 4, 4, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 104, 1 },
                    { 5, 3, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, true, false, 105, 1 },
                    { 6, 3, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, false, false, true, 106, 1 },
                    { 7, 3, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, false, false, true, 107, 1 },
                    { 8, 2, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 201, 1 },
                    { 9, 1, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 202, 2 },
                    { 10, 4, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 203, 2 },
                    { 11, 1, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 204, 1 },
                    { 12, 1, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, false, false, false, 205, 1 },
                    { 13, 1, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, true, 205, 1 },
                    { 14, 2, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 301, 3 },
                    { 15, 1, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 302, 2 },
                    { 16, 4, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 303, 3 },
                    { 17, 4, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, false, false, false, 303, 3 },
                    { 18, 2, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true, true, false, false, 401, 4 },
                    { 19, 2, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true, true, false, false, 402, 4 }
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

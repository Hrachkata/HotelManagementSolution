using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class InitalAfterUpdatesRemovedGuest : Migration
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
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GuestFirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GuestLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GuestNationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GuestPhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GuestEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    { new Guid("4729c0de-06d9-4f3b-88d9-7a642e295b16"), "ecefdf7d-98dd-4141-89ae-69cde11c7a4d", "Manager", "MANAGER" },
                    { new Guid("53fb00eb-25fa-432b-a606-834d44ddd77d"), "9b8581eb-9df7-4bac-b113-56ceea5c0ff5", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("57c91138-6787-42c4-8ec1-4d1b24f288f9"), "3b63a464-bd31-4f10-9f0f-0d9e3b1bd79b", "f&b", "F&B" },
                    { new Guid("6ac92501-81d7-4352-af47-39d6f0cae200"), "de7f4fee-6720-4e2d-b7d6-ec75ad7fce8e", "Director", "DIRECTOR" },
                    { new Guid("7700fc19-4f7e-49ce-b9de-c65125a267bf"), "5f0ec057-6b8f-4e60-a9c1-29402adb2e3b", "Owner", "OWNER" },
                    { new Guid("cfe8ad68-27e9-493c-8a54-2cc4f99c2172"), "58438375-58b1-4acd-bd51-15243231c463", "Admin", "ADMIN" },
                    { new Guid("d4197625-6e1f-4a86-986d-694a7389670f"), "8616597b-a13d-4b68-9cdf-faff53d8858d", "Front Desk", "FRONT DESK" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("63b55242-19bb-47fa-bc5e-fa6cd014bfa3"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5c0a76f6-5e22-4b80-a547-a6aa9003b7e6", new DateTime(2022, 12, 5, 0, 18, 45, 177, DateTimeKind.Local).AddTicks(2897), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAELu+P0z9xZxKJ7tKiU0pc/ViBKCFIN73QJrwXHg5IPoBp31KqruebRuIGz1SH+Mcwg==", "1234567890", false, "123456789", 0m, "143dc87e-bb4e-425a-a74e-e2463a628558", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "EditedOn", "EmployeeCount", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4257), null, "Some Department", null, null, true, "F&B" },
                    { 2, new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4301), null, "This is the human resource department with access to employee management and hiring new employees.", null, null, true, "Human Resources" },
                    { 3, new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4306), null, "This is the IT department with access to employee management, hiring new employees, admin panel and front desk.", null, null, true, "IT department" },
                    { 4, new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4311), null, "This is the front desk/reception department with access to reservations and front desk.", null, null, true, "Reservations" },
                    { 5, new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4507), null, "This is the director department with access to employee management, hiring new employees, admin panel and front desk.", null, null, true, "Director" },
                    { 6, new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4519), null, "This is full access! NOT RECOMMENDED", null, null, true, "Owner" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "EditedOn", "FloorNumber", "IsActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true },
                    { 2, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true },
                    { 3, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true },
                    { 4, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true }
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
                    { 1, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 100m, "Standard" },
                    { 2, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 150m, "Apartment" },
                    { 3, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 250m, "Deluxe" },
                    { 4, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, true, 400m, "President" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7700fc19-4f7e-49ce-b9de-c65125a267bf"), new Guid("63b55242-19bb-47fa-bc5e-fa6cd014bfa3") });

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
                    { 1, 3, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 101, 1 },
                    { 2, 4, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 102, 2 },
                    { 3, 4, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 103, 2 },
                    { 4, 4, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 104, 1 },
                    { 5, 3, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 105, 1 },
                    { 6, 3, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, false, false, true, 106, 1 },
                    { 7, 3, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, false, false, true, 107, 1 },
                    { 8, 2, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 201, 1 },
                    { 9, 1, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 202, 2 },
                    { 10, 4, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 203, 2 },
                    { 11, 1, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 204, 1 },
                    { 12, 1, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, false, false, false, 205, 1 },
                    { 13, 1, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, true, 205, 1 },
                    { 14, 2, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 301, 3 },
                    { 15, 1, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 302, 2 },
                    { 16, 4, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 303, 3 },
                    { 17, 4, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, false, false, false, 303, 3 },
                    { 18, 2, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true, true, false, false, 401, 4 },
                    { 19, 2, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true, true, false, false, 402, 4 }
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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class AdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16481f01-7bd9-48d2-9b12-7f394d8ed00d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3147518d-6626-4d32-92df-f91c9f3ff7d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a8da73b8-a1db-4f20-b99a-b1c467783094"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8e0f37ef-2b53-4348-b8ad-82b5449094c9"), new Guid("47012d7f-fc35-4a08-bb38-dd9739557c5a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e0f37ef-2b53-4348-b8ad-82b5449094c9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("47012d7f-fc35-4a08-bb38-dd9739557c5a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("171c3186-f57e-4327-ad5d-52464b754891"), "3aee67b8-1b57-4caf-a16e-4c56e112746d", "Director", "DIRECTOR" },
                    { new Guid("454f70be-fd78-404e-a29e-299d7f3c898f"), "3d9e129b-d624-4ede-af8f-df953b7d1d13", "Admin", "ADMIN" },
                    { new Guid("93349ce1-1ba0-40d7-8313-4c766388168d"), "8f74fcc3-0a39-47a3-8f05-838c13fe47fa", "FrontDesk", "FRONTDESK" },
                    { new Guid("9fc721d8-ccc2-449c-b1be-f7a5057bfe51"), "55cc9c8f-4692-4ca4-ac37-2d6fd308abfa", "HumanResources", "HUMANRESOURCES" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6b71f31f-d145-4b65-894a-408c9c807271"), 0, "7e6fc61c-0f08-4360-940b-18c084e8e0bd", new DateTime(2022, 11, 1, 22, 24, 38, 356, DateTimeKind.Local).AddTicks(973), null, null, "admin@gmail.com", true, "Admin", true, "Admin", false, null, null, null, "AQAAAAEAACcQAAAAEKTEzQRug2mMdD08iDgIcv2zlkOLcq3IHLCg6NniPv0PJ9fQ9FiSK6FrkxGmE1GLtQ==", "1234567890", false, "234", 1m, null, false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 24, 38, 366, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 24, 38, 366, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 24, 38, 366, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 24, 38, 366, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 24, 38, 366, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("454f70be-fd78-404e-a29e-299d7f3c898f"), new Guid("6b71f31f-d145-4b65-894a-408c9c807271") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("171c3186-f57e-4327-ad5d-52464b754891"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93349ce1-1ba0-40d7-8313-4c766388168d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9fc721d8-ccc2-449c-b1be-f7a5057bfe51"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("454f70be-fd78-404e-a29e-299d7f3c898f"), new Guid("6b71f31f-d145-4b65-894a-408c9c807271") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("454f70be-fd78-404e-a29e-299d7f3c898f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6b71f31f-d145-4b65-894a-408c9c807271"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("16481f01-7bd9-48d2-9b12-7f394d8ed00d"), "d8b8376d-4137-4480-812f-6cd71612c9d0", "HumanResources", "HUMANRESOURCES" },
                    { new Guid("3147518d-6626-4d32-92df-f91c9f3ff7d1"), "fa1ee725-5e58-4576-a321-26c69d43b735", "Director", "DIRECTOR" },
                    { new Guid("8e0f37ef-2b53-4348-b8ad-82b5449094c9"), "2ba1ebc4-3f07-4ebc-bac8-2b6315371996", "Admin", "ADMIN" },
                    { new Guid("a8da73b8-a1db-4f20-b99a-b1c467783094"), "315f85e1-8e10-45f2-a54e-61fbd12b94dd", "FrontDesk", "FRONTDESK" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("47012d7f-fc35-4a08-bb38-dd9739557c5a"), 0, "fff81d6d-9bed-41b6-8631-dec2deb58ce0", new DateTime(2022, 11, 1, 22, 10, 27, 262, DateTimeKind.Local).AddTicks(2242), null, null, "admin@gmail.com", true, "Admin", true, "Admin", false, null, null, null, null, "1234567890", false, "234", 1m, null, false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 10, 27, 272, DateTimeKind.Local).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 10, 27, 272, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 10, 27, 272, DateTimeKind.Local).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 10, 27, 272, DateTimeKind.Local).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 1, 22, 10, 27, 272, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8e0f37ef-2b53-4348-b8ad-82b5449094c9"), new Guid("47012d7f-fc35-4a08-bb38-dd9739557c5a") });
        }
    }
}

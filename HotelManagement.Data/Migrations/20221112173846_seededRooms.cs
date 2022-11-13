using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class seededRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0f0aad09-b5a4-40f3-adba-3ad67f41f2c9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17b3dea0-ba4f-460d-b60d-0dba4af7afb0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1c5b26ce-8ee9-47cf-a4bf-526aae69a92e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43a9d6b2-a821-4b06-879f-c623fb751c69"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c43d1435-5a5a-4700-8bfb-74d4b4dca159"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d9ecaa0b-2ec7-4bd4-9f9a-d4477c091a5b"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c13ec518-8ffa-4b83-8614-bacbb5c0540a"), new Guid("29687e07-0703-4e14-9361-e66b81b78c3c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c13ec518-8ffa-4b83-8614-bacbb5c0540a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("29687e07-0703-4e14-9361-e66b81b78c3c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("20e0135f-fd6f-4eb5-bc00-39828b2cefb0"), "d17ecc7d-e20b-4b7f-9936-b8942963c6d9", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("2cb45702-185c-489e-ade7-1da270cdd121"), "f7b17221-2d39-40c3-be85-9b298389155f", "Manager", "MANAGER" },
                    { new Guid("7b78618b-a2f9-4854-8339-44e559db94fe"), "17a27ad0-2c6a-42f3-8b87-e1d0630e922f", "Owner", "OWNER" },
                    { new Guid("814efdb4-2d83-4111-8ccb-10040cd72ce4"), "d073d82e-0016-4616-bb61-3416ae53ef75", "Director", "DIRECTOR" },
                    { new Guid("98009538-c809-4ca1-92d0-01ccb4f9e74d"), "76da6744-c52b-4cb0-9292-f20b14ca93d9", "f&b", "F&B" },
                    { new Guid("c29b18bb-fb16-4aec-ad82-bb72b2de8291"), "c836efe8-0f38-4633-9d5c-aca6dbe3b02d", "Front Desk", "FRONT DESK" },
                    { new Guid("fab11826-bb04-4669-be3d-4227fb5aabde"), "77fc0aea-b21b-4662-8e9e-1cc24c31afae", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("adce50d0-f639-4e50-b814-32900120ef82"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7d62b830-c2d0-4fa1-beee-c62d8ea342e0", new DateTime(2022, 11, 12, 19, 38, 45, 112, DateTimeKind.Local).AddTicks(510), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAELlWzRhHq+rhQ0rygGbhVi0tRuDU6YXa4uf58uQKQpVjuar/I0TTuZhKvFqQ0p8poA==", "1234567890", false, "123456789", 0m, "5e997dd9-594b-445a-9b3e-c2ed21a9a6d0", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 38, 45, 120, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 38, 45, 120, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 38, 45, 120, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 38, 45, 120, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 38, 45, 120, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 38, 45, 120, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "CreatedOn", "DeletedOn", "EditedOn", "FloorId", "IsActive", "IsCleaned", "IsOccupied", "IsOutOfService", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 101, 1 },
                    { 2, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 102, 2 },
                    { 3, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 103, 2 },
                    { 4, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 1, true, true, false, false, 104, 1 },
                    { 5, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 201, 1 },
                    { 6, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 202, 2 },
                    { 7, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 203, 2 },
                    { 8, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 2, true, true, false, false, 204, 1 },
                    { 9, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 301, 3 },
                    { 10, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 302, 2 },
                    { 11, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 3, true, true, false, false, 303, 3 },
                    { 12, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true, true, false, false, 401, 4 },
                    { 13, 0, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true, true, false, false, 402, 4 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7b78618b-a2f9-4854-8339-44e559db94fe"), new Guid("adce50d0-f639-4e50-b814-32900120ef82") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("20e0135f-fd6f-4eb5-bc00-39828b2cefb0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2cb45702-185c-489e-ade7-1da270cdd121"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("814efdb4-2d83-4111-8ccb-10040cd72ce4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98009538-c809-4ca1-92d0-01ccb4f9e74d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c29b18bb-fb16-4aec-ad82-bb72b2de8291"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fab11826-bb04-4669-be3d-4227fb5aabde"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7b78618b-a2f9-4854-8339-44e559db94fe"), new Guid("adce50d0-f639-4e50-b814-32900120ef82") });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b78618b-a2f9-4854-8339-44e559db94fe"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("adce50d0-f639-4e50-b814-32900120ef82"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0f0aad09-b5a4-40f3-adba-3ad67f41f2c9"), "81cb167a-4878-499c-9414-3d56a6d41cf9", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("17b3dea0-ba4f-460d-b60d-0dba4af7afb0"), "73fbeb36-5e5c-4a97-8e28-d4de85bebc04", "Director", "DIRECTOR" },
                    { new Guid("1c5b26ce-8ee9-47cf-a4bf-526aae69a92e"), "f0448e63-3bd2-4f0f-9a94-cddbcf104b93", "f&b", "F&B" },
                    { new Guid("43a9d6b2-a821-4b06-879f-c623fb751c69"), "129348b0-2386-4db9-b185-5adda98402d9", "Admin", "ADMIN" },
                    { new Guid("c13ec518-8ffa-4b83-8614-bacbb5c0540a"), "3d81aab0-8bde-4015-ab27-74bc4eb2bfef", "Owner", "OWNER" },
                    { new Guid("c43d1435-5a5a-4700-8bfb-74d4b4dca159"), "d2a9b99b-34ea-4d69-bf61-6e87aacb9696", "Manager", "MANAGER" },
                    { new Guid("d9ecaa0b-2ec7-4bd4-9f9a-d4477c091a5b"), "031fca8e-6e4c-4d8f-bd0b-930fc6be86cb", "Front Desk", "FRONT DESK" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("29687e07-0703-4e14-9361-e66b81b78c3c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1e5b3022-728e-4c97-86fc-544a5298a5d6", new DateTime(2022, 11, 12, 19, 36, 27, 822, DateTimeKind.Local).AddTicks(3552), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEIciaRiA1uv9pwFqhEFxFLZzC3uRmzJeSVoEOtXLozVvnq5TRYyfkUeENtEgPAQUZg==", "1234567890", false, "123456789", 0m, "2415c969-c6fa-4b93-b965-c443fcc99877", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 36, 27, 830, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 36, 27, 830, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 36, 27, 830, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 36, 27, 830, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 36, 27, 830, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 36, 27, 830, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c13ec518-8ffa-4b83-8614-bacbb5c0540a"), new Guid("29687e07-0703-4e14-9361-e66b81b78c3c") });
        }
    }
}

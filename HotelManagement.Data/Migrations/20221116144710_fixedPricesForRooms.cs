using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class fixedPricesForRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0757b110-1ae7-4af7-b4e9-af1b541091d9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("298d5285-4bba-4620-bf75-09de19436caf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ecd2379-2bae-483e-83e5-9953ba4a10df"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2f79e53-72b5-4bca-88dd-a5d46c1c62eb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9b35ead-7fa8-4332-9e67-f891d6fda49f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffd6fd99-aec2-450c-943a-f8a1fb98f907"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cc39ac6b-aa81-4333-b7bb-c93364ca6cf1"), new Guid("a6d39935-2ee0-4708-a5d8-7b7f58243812") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc39ac6b-aa81-4333-b7bb-c93364ca6cf1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a6d39935-2ee0-4708-a5d8-7b7f58243812"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01e44089-2904-44e0-9811-dbe64f2a4fc7"), "9ab412ab-4348-4bbf-a927-b5219fff558c", "Director", "DIRECTOR" },
                    { new Guid("01f951c3-39c3-455d-b93c-7eef961620ce"), "b94204aa-685a-43eb-bd52-f57f84a784dc", "Manager", "MANAGER" },
                    { new Guid("467f7646-2965-49a5-a0c1-75c7281bf0bb"), "0b9768e2-dfc4-47b3-82f5-19c183c0c5de", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("656a43f2-b3b8-4bfd-99ca-5bf3cf0adff5"), "ae45b247-076f-4d9b-bf67-31b4125254e7", "Owner", "OWNER" },
                    { new Guid("71ac74ac-be22-4a86-bb3a-72662bce677b"), "fdf5375a-5cc2-4c8b-9ef8-27b393ce78b2", "Front Desk", "FRONT DESK" },
                    { new Guid("8b6480d6-b19c-456f-a0eb-99abd28ac202"), "0b4362cb-1039-47e5-b8f7-06e064bee379", "Admin", "ADMIN" },
                    { new Guid("c1f08c44-c6fd-43a1-900a-1c686eb8e74b"), "38a8a97a-f1ef-4c6f-9a52-bac932c91684", "f&b", "F&B" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("5d0f13b7-95ae-42f6-b4c3-0db6613ad2cf"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d96edb43-9bd1-4dc2-ab98-2bcbdacd234a", new DateTime(2022, 11, 16, 16, 47, 9, 549, DateTimeKind.Local).AddTicks(1003), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEH3UYwgyGMzx6bfw8jFjhEBDjObkZb6vWN/7NcOEG3pv6QS4DnKUNzeSCFf8zFIYQQ==", "1234567890", false, "123456789", 0m, "b6132ff0-7b6d-4187-8265-b1360892476f", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 47, 9, 558, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 47, 9, 558, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 47, 9, 558, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 47, 9, 558, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 47, 9, 558, DateTimeKind.Local).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 47, 9, 558, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PricePerPerson",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PricePerPerson",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PricePerPerson",
                value: 250m);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PricePerPerson",
                value: 400m);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("656a43f2-b3b8-4bfd-99ca-5bf3cf0adff5"), new Guid("5d0f13b7-95ae-42f6-b4c3-0db6613ad2cf") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01e44089-2904-44e0-9811-dbe64f2a4fc7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01f951c3-39c3-455d-b93c-7eef961620ce"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("467f7646-2965-49a5-a0c1-75c7281bf0bb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("71ac74ac-be22-4a86-bb3a-72662bce677b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b6480d6-b19c-456f-a0eb-99abd28ac202"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1f08c44-c6fd-43a1-900a-1c686eb8e74b"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("656a43f2-b3b8-4bfd-99ca-5bf3cf0adff5"), new Guid("5d0f13b7-95ae-42f6-b4c3-0db6613ad2cf") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("656a43f2-b3b8-4bfd-99ca-5bf3cf0adff5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5d0f13b7-95ae-42f6-b4c3-0db6613ad2cf"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0757b110-1ae7-4af7-b4e9-af1b541091d9"), "e0d7e707-044b-4745-8e2c-5a36d810953e", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("298d5285-4bba-4620-bf75-09de19436caf"), "f9ae9e62-689e-479c-a95e-b3db51f03a6b", "Manager", "MANAGER" },
                    { new Guid("4ecd2379-2bae-483e-83e5-9953ba4a10df"), "40461da0-d388-4543-8365-2215e843053c", "Admin", "ADMIN" },
                    { new Guid("a2f79e53-72b5-4bca-88dd-a5d46c1c62eb"), "f08af1cc-a8c4-4dc0-81cc-4b2552dd1346", "Front Desk", "FRONT DESK" },
                    { new Guid("cc39ac6b-aa81-4333-b7bb-c93364ca6cf1"), "a79d5cd6-f660-4e40-bc75-a54374671edb", "Owner", "OWNER" },
                    { new Guid("e9b35ead-7fa8-4332-9e67-f891d6fda49f"), "92b0cb9c-d4cb-4bb9-87b9-69a0ce68fe34", "f&b", "F&B" },
                    { new Guid("ffd6fd99-aec2-450c-943a-f8a1fb98f907"), "2ddd29fd-4215-4507-ab8a-7c27f23169ab", "Director", "DIRECTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a6d39935-2ee0-4708-a5d8-7b7f58243812"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b65f593a-271c-488c-9849-a1d5d3fed206", new DateTime(2022, 11, 16, 16, 3, 50, 134, DateTimeKind.Local).AddTicks(1971), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEFGpvvlnQSfA+3sVuSEZkKiauwBMvcqPs6XuRdzFcw2kokbk84KJoBwDNBftBGOywA==", "1234567890", false, "123456789", 0m, "449a083f-263d-4fab-83d3-836716896ee9", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 3, 50, 144, DateTimeKind.Local).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 3, 50, 144, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 3, 50, 144, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 3, 50, 144, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 3, 50, 144, DateTimeKind.Local).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 16, 3, 50, 144, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PricePerPerson",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PricePerPerson",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PricePerPerson",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PricePerPerson",
                value: 0m);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cc39ac6b-aa81-4333-b7bb-c93364ca6cf1"), new Guid("a6d39935-2ee0-4708-a5d8-7b7f58243812") });
        }
    }
}

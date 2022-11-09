using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d2e0de0-526a-4a70-a516-17f6730f11a8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("205fdd2e-7b4c-468d-961b-833ef09e5eb9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("47c95e9a-c472-49fa-a67a-1f2a79c4c42a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("89a50641-5700-4d07-831d-2055c4a08952"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bbdb2929-6ad3-4d2a-9023-87a0deadd228"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dbecc955-9e3e-4020-994f-8cf50f794258"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6236d32-63e2-44fc-b6aa-c605f98b55fb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d7f6958-2af8-4256-9579-95c961e481a6"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("365bf314-9750-4a29-b676-20545aea6d21"), "a4953987-955b-4762-a84c-ce31abfb17af", "Director", "DIRECTOR" },
                    { new Guid("3b6d48ea-0f56-4dee-bc00-7e4489cd1d51"), "b4b648dd-de75-4887-ab5b-3b6bd7d5ee42", "Owner", "OWNER" },
                    { new Guid("547fd860-99d3-4f19-ad8f-824ee837941d"), "649a73ee-0b38-4fd4-a956-adbf0cdf7139", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("865f129d-81a1-4109-91d1-6a448a16bf04"), "a7d07c24-ee4b-49d9-bcf4-c6addaf9d817", "f&b", "F&B" },
                    { new Guid("8e3f7bb5-23c9-4edf-90a1-fb7df35bd9b6"), "20eb8503-3dc1-4dc6-989f-4dc96479ead2", "Manager", "MANAGER" },
                    { new Guid("ab08c546-b7a7-4c31-9417-526f542c3812"), "8c2b7eb1-6223-4110-841b-53320d383838", "Front Desk", "FRONT DESK" },
                    { new Guid("e17d0ad3-e193-43e2-a013-85f58c6fc037"), "63ca2c04-11cf-418d-a56e-28a03dc29e6a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("be78793b-260f-435e-bc1a-91cd6c39b7c5"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "084da9c4-7a80-4eba-bb3a-6a7e666b42d9", new DateTime(2022, 11, 9, 14, 33, 28, 115, DateTimeKind.Local).AddTicks(5683), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEFr5AqvPiGwaAVH0MrpbwdARBvXk+iZm3JoC8kkvTAI+Hw4TwIBbHT0beNheeexAJQ==", "1234567890", false, "123456789", 0m, "2d5f8b4c-2c61-4972-9766-29f57eef592a", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 33, 28, 123, DateTimeKind.Local).AddTicks(5265));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3b6d48ea-0f56-4dee-bc00-7e4489cd1d51"), new Guid("be78793b-260f-435e-bc1a-91cd6c39b7c5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("365bf314-9750-4a29-b676-20545aea6d21"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("547fd860-99d3-4f19-ad8f-824ee837941d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("865f129d-81a1-4109-91d1-6a448a16bf04"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e3f7bb5-23c9-4edf-90a1-fb7df35bd9b6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab08c546-b7a7-4c31-9417-526f542c3812"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e17d0ad3-e193-43e2-a013-85f58c6fc037"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3b6d48ea-0f56-4dee-bc00-7e4489cd1d51"), new Guid("be78793b-260f-435e-bc1a-91cd6c39b7c5") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3b6d48ea-0f56-4dee-bc00-7e4489cd1d51"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be78793b-260f-435e-bc1a-91cd6c39b7c5"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1d2e0de0-526a-4a70-a516-17f6730f11a8"), "839976df-3db1-4c75-a05d-e69343c6ec4e", "Manager", "MANAGER" },
                    { new Guid("205fdd2e-7b4c-468d-961b-833ef09e5eb9"), "c819c541-f6ad-413e-917a-7430d35750aa", "Admin", "ADMIN" },
                    { new Guid("47c95e9a-c472-49fa-a67a-1f2a79c4c42a"), "0c1387cc-5048-43d2-acca-ea332db7c59b", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("89a50641-5700-4d07-831d-2055c4a08952"), "4728100a-8064-429e-aaca-d63dcfd89731", "Director", "DIRECTOR" },
                    { new Guid("bbdb2929-6ad3-4d2a-9023-87a0deadd228"), "a76c08b7-7c10-41ff-9a23-b71cc2c3b78a", "f&b", "F&B" },
                    { new Guid("dbecc955-9e3e-4020-994f-8cf50f794258"), "94af6c7a-f494-40da-a13d-e492b7d0c496", "Owner", "OWNER" },
                    { new Guid("f6236d32-63e2-44fc-b6aa-c605f98b55fb"), "0cb8d028-2852-4d7c-b2ff-5a41c03bb843", "Front Desk", "FRONT DESK" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3d7f6958-2af8-4256-9579-95c961e481a6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "34f2739a-50ec-4a03-87e5-2143a7e16ffd", new DateTime(2022, 11, 9, 14, 32, 50, 64, DateTimeKind.Local).AddTicks(4349), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEFtrXtH3qRo4E5CRsacnFnlwIuWXLhYWDKyAPZFs3yvOvwbtlnH9BwRHjHkKhxxKbw==", "1234567890", false, "123456789", 0m, "2df7df82-555a-48de-b166-26f741bb94f1", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 32, 50, 73, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 32, 50, 73, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 32, 50, 73, DateTimeKind.Local).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 32, 50, 73, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 32, 50, 73, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 32, 50, 73, DateTimeKind.Local).AddTicks(2410));
        }
    }
}

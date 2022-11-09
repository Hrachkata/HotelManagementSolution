using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("06b91714-4fd6-4c73-a109-fea3abbf890f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("163e24fd-1cfd-496f-acce-a738305125d3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e23431d-ef8c-465b-90ff-8cadc5a56321"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26ceaedb-4474-4a1d-ac1b-3e5d5e52b943"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("41c178be-4dd7-4ca9-91cd-b5d373f80b83"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fd3dece-a64b-40df-9b6c-8bba2a9677d3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("db5d30ad-9f30-401e-a825-6d12e08d50b9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("735f0c4f-2207-4fab-ba30-0562c8ba83bc"));

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

            migrationBuilder.InsertData(
                table: "RolesDepartments",
                columns: new[] { "DepartmentId", "RoleNameId" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 3, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 5, 3 },
                    { 6, 3 },
                    { 6, 4 },
                    { 5, 5 },
                    { 6, 5 },
                    { 3, 6 },
                    { 6, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("06b91714-4fd6-4c73-a109-fea3abbf890f"), "8f529d4d-29d6-4afb-af50-83830c9cd7ca", "Manager", "MANAGER" },
                    { new Guid("163e24fd-1cfd-496f-acce-a738305125d3"), "82792818-1b92-46a4-9633-62de2daebc26", "Front Desk", "FRONT DESK" },
                    { new Guid("1e23431d-ef8c-465b-90ff-8cadc5a56321"), "5b16e0b2-468f-4d35-b865-70f2c97d6a21", "Admin", "ADMIN" },
                    { new Guid("26ceaedb-4474-4a1d-ac1b-3e5d5e52b943"), "1e3ce39a-991d-43ea-9e86-4d92ddcdcbd7", "f&b", "F&B" },
                    { new Guid("41c178be-4dd7-4ca9-91cd-b5d373f80b83"), "085d4eef-aa2f-4812-9a08-1dada6d6f4ef", "Director", "DIRECTOR" },
                    { new Guid("6fd3dece-a64b-40df-9b6c-8bba2a9677d3"), "863cbd78-dd2c-43b9-849d-3707ad162aa2", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("db5d30ad-9f30-401e-a825-6d12e08d50b9"), "e3ab0cf3-0f07-4963-beef-9850bd363d75", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("735f0c4f-2207-4fab-ba30-0562c8ba83bc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "927071ae-f390-42a3-89c5-fe87701b1248", new DateTime(2022, 11, 9, 14, 27, 30, 99, DateTimeKind.Local).AddTicks(5922), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEC7EOCBVX4RGHm+wyShMtkw/bj9+1oDnswF2UoDk3DQBg4ye4FPP3NMdAhGxXVENyA==", "1234567890", false, "123456789", 0m, "1b4f5ce5-fa5c-476d-afac-fee9057af5bb", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 27, 30, 108, DateTimeKind.Local).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 27, 30, 108, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 27, 30, 108, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 27, 30, 108, DateTimeKind.Local).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 27, 30, 108, DateTimeKind.Local).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 27, 30, 108, DateTimeKind.Local).AddTicks(8905));
        }
    }
}

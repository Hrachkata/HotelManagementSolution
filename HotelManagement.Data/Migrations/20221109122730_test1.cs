using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("224fcb7e-4cf2-4b79-9b0e-6c5e66b6e2fb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5eaee231-c6e5-466b-8496-9f4b00bc6d9f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8a9279bf-2862-4383-be06-fce1abd1f485"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("99c55569-1edf-4ac1-a1c7-46be55b6d707"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a35d3a90-36a4-4cdc-8c67-5e1ea4447a86"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b4f3ae33-46f3-4540-bc4b-ffc825ff4a2b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f056ab5a-60c4-4dfd-ae14-e973ab69276c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b3b355ca-1fc4-4a7b-b881-33d7ace0f390"));

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

            migrationBuilder.InsertData(
                table: "RolesDepartments",
                columns: new[] { "DepartmentId", "RoleNameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RolesDepartments",
                keyColumns: new[] { "DepartmentId", "RoleNameId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("224fcb7e-4cf2-4b79-9b0e-6c5e66b6e2fb"), "31b89a3b-adda-4765-8ac4-933f49a48189", "Director", "DIRECTOR" },
                    { new Guid("5eaee231-c6e5-466b-8496-9f4b00bc6d9f"), "4edd4ba0-0984-4a3c-967d-27e2b4b760ee", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("8a9279bf-2862-4383-be06-fce1abd1f485"), "6b2e37e1-a6f4-404d-8e72-42203027fa79", "f&b", "F&B" },
                    { new Guid("99c55569-1edf-4ac1-a1c7-46be55b6d707"), "0ec40cd2-0367-454f-9743-cee3e0d931ed", "Front Desk", "FRONT DESK" },
                    { new Guid("a35d3a90-36a4-4cdc-8c67-5e1ea4447a86"), "5d4b38be-a11f-44f5-b31e-7229ccc6eed8", "Manager", "MANAGER" },
                    { new Guid("b4f3ae33-46f3-4540-bc4b-ffc825ff4a2b"), "2d70d64a-e5e6-4a7c-9665-0a0a675fb53e", "Admin", "ADMIN" },
                    { new Guid("f056ab5a-60c4-4dfd-ae14-e973ab69276c"), "5fefa8b4-3e38-4c20-a325-4ea20b597c95", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b3b355ca-1fc4-4a7b-b881-33d7ace0f390"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "56a4ebfa-1df9-4df0-bef3-5057a94ae87c", new DateTime(2022, 11, 9, 14, 21, 3, 954, DateTimeKind.Local).AddTicks(9902), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAECZAGVqqU4c13g0F3Y5EulPf9u7bEUkpbwUnwb+RoPUpVH58opvrS8chxVyGBLBv0A==", "1234567890", false, "123456789", 0m, "21e15b46-11cb-433f-a2a9-7139b52071c0", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 21, 3, 962, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 21, 3, 962, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 21, 3, 962, DateTimeKind.Local).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 21, 3, 962, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 21, 3, 962, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 14, 21, 3, 962, DateTimeKind.Local).AddTicks(7292));
        }
    }
}

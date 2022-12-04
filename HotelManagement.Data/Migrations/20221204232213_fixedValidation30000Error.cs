using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class fixedValidation30000Error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4729c0de-06d9-4f3b-88d9-7a642e295b16"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("53fb00eb-25fa-432b-a606-834d44ddd77d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("57c91138-6787-42c4-8ec1-4d1b24f288f9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6ac92501-81d7-4352-af47-39d6f0cae200"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfe8ad68-27e9-493c-8a54-2cc4f99c2172"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4197625-6e1f-4a86-986d-694a7389670f"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7700fc19-4f7e-49ce-b9de-c65125a267bf"), new Guid("63b55242-19bb-47fa-bc5e-fa6cd014bfa3") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7700fc19-4f7e-49ce-b9de-c65125a267bf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63b55242-19bb-47fa-bc5e-fa6cd014bfa3"));

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerPerson",
                table: "RoomTypes",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "totalPrice",
                table: "Reservations",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "AspNetUsers",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0c235dd9-4a14-4093-81d6-d4e8014c841a"), "17ad01f7-b18c-4c17-bd57-10b7fd982aa7", "Front Desk", "FRONT DESK" },
                    { new Guid("3b95d0e0-4ee9-42fa-9940-edb0eafac0d1"), "896aa844-56aa-4cec-9d9a-c579b0081adf", "Director", "DIRECTOR" },
                    { new Guid("50e0a58c-df91-4a00-8ba0-0cf5d6a5d2c5"), "80f65e2c-a01f-4c6a-bd9e-56fdd55bfd3d", "Manager", "MANAGER" },
                    { new Guid("7c629d64-c74c-41a5-b3be-bd78cacbc271"), "5a99cb9d-b2f2-444c-90c1-47117ce609b3", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("943ad1eb-643f-47a8-afb1-04221539797f"), "aad800bb-9eaa-4a9a-8758-b5b729e7a45e", "Owner", "OWNER" },
                    { new Guid("eeb33928-94ca-4039-808d-3dec7066e4c3"), "03fcabbc-3dea-44da-8280-07b256da4494", "f&b", "F&B" },
                    { new Guid("f0ae5ffb-c4ff-487e-a455-a89b7c134a51"), "e71e0c7b-90a9-4fcf-849f-672f8075f1c3", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("efa93f46-6d8c-4afd-9ad5-bd8f52b8f3ad"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ff606ed3-e7e7-47ea-8571-ac1b7aeb2f67", new DateTime(2022, 12, 5, 1, 22, 12, 651, DateTimeKind.Local).AddTicks(4383), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEGqyMx4qOdFWJFR0GLtcpYzYYEEV8JP9BNiWnW2jpWdOQVmiI9UtNxND23drtesCXQ==", "1234567890", false, "123456789", 0m, "8d1d1be6-cfa6-4ec2-90ef-68eb160a2c1b", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 1, 22, 12, 659, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 1, 22, 12, 659, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 1, 22, 12, 659, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 1, 22, 12, 659, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 1, 22, 12, 659, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 1, 22, 12, 659, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("943ad1eb-643f-47a8-afb1-04221539797f"), new Guid("efa93f46-6d8c-4afd-9ad5-bd8f52b8f3ad") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c235dd9-4a14-4093-81d6-d4e8014c841a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3b95d0e0-4ee9-42fa-9940-edb0eafac0d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("50e0a58c-df91-4a00-8ba0-0cf5d6a5d2c5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c629d64-c74c-41a5-b3be-bd78cacbc271"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eeb33928-94ca-4039-808d-3dec7066e4c3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0ae5ffb-c4ff-487e-a455-a89b7c134a51"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("943ad1eb-643f-47a8-afb1-04221539797f"), new Guid("efa93f46-6d8c-4afd-9ad5-bd8f52b8f3ad") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("943ad1eb-643f-47a8-afb1-04221539797f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efa93f46-6d8c-4afd-9ad5-bd8f52b8f3ad"));

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerPerson",
                table: "RoomTypes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "totalPrice",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

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

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 5, 0, 18, 45, 186, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7700fc19-4f7e-49ce-b9de-c65125a267bf"), new Guid("63b55242-19bb-47fa-bc5e-fa6cd014bfa3") });
        }
    }
}

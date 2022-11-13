using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    public partial class seedFloorsRemoved0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Floors",
                keyColumn: "Id",
                keyValue: 5);

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
                    { new Guid("25e74674-50a9-402b-a097-55958c62739d"), "f170860c-79ee-416b-9aa8-ca4112c2f40b", "Admin", "ADMIN" },
                    { new Guid("294f1126-2270-4415-8888-f4ce5f2bed1e"), "97d4095a-7ea7-4d2e-871f-26e564c1272b", "Front Desk", "FRONT DESK" },
                    { new Guid("6fd2c1ee-f0d6-4622-b8d9-0ff14ef0d15e"), "cac26701-17a8-493e-b815-6b77908e8623", "f&b", "F&B" },
                    { new Guid("74fad29d-28bc-455e-98ce-801b64f39861"), "caa99b24-a898-4ad7-9947-d541aeeb4ac7", "Director", "DIRECTOR" },
                    { new Guid("77551352-f288-4265-a52b-cfeddf5e9285"), "28e67f48-68b7-4012-be52-61cb371ee415", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("c7a3dd00-4a05-44c3-ac9e-6597d056acbf"), "f87ef73b-6c6f-4972-b4ff-452cf7480546", "Owner", "OWNER" },
                    { new Guid("fa3e317f-6238-4156-9817-ac7893f8de93"), "4c02a730-0536-4969-a711-8bb48f451d5f", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("951259bb-5721-4370-9ce7-ef8ee10290cc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9479c237-0ed9-44fb-bccb-59386f88cfd0", new DateTime(2022, 11, 12, 19, 41, 42, 724, DateTimeKind.Local).AddTicks(7326), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAENeCETE09xWRQfhifRQFvNIhEFVh0U1BCaFJoXfdhrtjHG6xRVxtEbn1mqHY542DDQ==", "1234567890", false, "123456789", 0m, "20090f32-f748-4c86-9bb4-56ef19341333", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 41, 42, 733, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 41, 42, 733, DateTimeKind.Local).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 41, 42, 733, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 41, 42, 733, DateTimeKind.Local).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 41, 42, 733, DateTimeKind.Local).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 19, 41, 42, 733, DateTimeKind.Local).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 1,
                column: "FloorNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 2,
                column: "FloorNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 3,
                column: "FloorNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 4,
                column: "FloorNumber",
                value: 4);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c7a3dd00-4a05-44c3-ac9e-6597d056acbf"), new Guid("951259bb-5721-4370-9ce7-ef8ee10290cc") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25e74674-50a9-402b-a097-55958c62739d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("294f1126-2270-4415-8888-f4ce5f2bed1e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fd2c1ee-f0d6-4622-b8d9-0ff14ef0d15e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("74fad29d-28bc-455e-98ce-801b64f39861"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77551352-f288-4265-a52b-cfeddf5e9285"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fa3e317f-6238-4156-9817-ac7893f8de93"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c7a3dd00-4a05-44c3-ac9e-6597d056acbf"), new Guid("951259bb-5721-4370-9ce7-ef8ee10290cc") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7a3dd00-4a05-44c3-ac9e-6597d056acbf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("951259bb-5721-4370-9ce7-ef8ee10290cc"));

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

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 1,
                column: "FloorNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 2,
                column: "FloorNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 3,
                column: "FloorNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 4,
                column: "FloorNumber",
                value: 3);

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "EditedOn", "FloorNumber", "IsActive" },
                values: new object[] { 5, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), null, null, 4, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7b78618b-a2f9-4854-8339-44e559db94fe"), new Guid("adce50d0-f639-4e50-b814-32900120ef82") });
        }
    }
}

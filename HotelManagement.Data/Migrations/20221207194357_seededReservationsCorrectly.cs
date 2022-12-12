using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class seededReservationsCorrectly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("03c7e9c8-991e-4cf5-b1dd-b89c8a0354f2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("08a5b7ee-10d8-4370-b08c-11e0c53563b0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("661824fc-5d6b-4348-914c-f9f2e1f30391"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d39021a4-ee63-46d6-a007-e76da5362392"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ea172e7f-ff07-49d0-976d-5f9e2b955da4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7ff6da8-0a7e-4c97-9554-8e5f006a8c4e"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2da8c9bc-a563-4890-b6f6-f6466be822ad"), new Guid("2930464c-c435-40f4-a381-0bef0423f857") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0902201d-e2b8-4f3f-a165-cecf6df5cafe"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "0a5b7675-4437-47e1-a614-6d58b6fda482");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "3b19b085-8df1-4157-95d7-3b0e2fc544fe");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "453b7f24-89a4-404e-91a0-67ef3ebe842c");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "993ecb0a-5618-4704-9ef3-3d0aeac37b4a");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "c5da5173-ec00-437a-bd07-7056c58ade1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2da8c9bc-a563-4890-b6f6-f6466be822ad"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2930464c-c435-40f4-a381-0bef0423f857"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("08b4f8c4-b864-4a53-a32e-06de1bc719ac"), "d44c7d61-926d-4388-bc5a-cd1d3def6d96", "f&b", "F&B" },
                    { new Guid("0b2967c0-87f8-4634-8500-b6224f482bb7"), "9ea1191c-3c2c-445f-9a70-3d0986c1488f", "Front Desk", "FRONT DESK" },
                    { new Guid("2239660f-9cd7-40a5-8c95-a1041451b375"), "8e774255-5454-45f9-9d48-340055a53d77", "Owner", "OWNER" },
                    { new Guid("275f7748-cd52-48bb-8809-a84fa4f11e7e"), "f6392e6c-bcf0-47aa-80c0-aacd4556729f", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("49533d2e-e49c-4f9c-aebd-4c2296a792ea"), "a2e98dd7-a913-492a-baea-8f4a5466e29b", "Manager", "MANAGER" },
                    { new Guid("f23493fb-e3c0-4cea-8404-9b79361291d4"), "a4958d33-1d96-4ff1-a27b-df9cbb2a46dd", "Admin", "ADMIN" },
                    { new Guid("f2e65074-9d5d-428b-8e33-917b11d323f5"), "3d8f28a1-4bc3-4de2-8928-8edb734d6d74", "Director", "DIRECTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("36fdc4d6-b4cc-4608-8f95-03c45b3c645f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23d715aa-ff53-409b-8792-ee33f39391ba", new DateTime(2022, 12, 7, 21, 43, 56, 305, DateTimeKind.Local).AddTicks(9314), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAELoqjr00aDM4zu/IT+YOfqVCNVE7ecgiLPacsFyHZecmm/wK7cXMeSjzNtiHASrecw==", "1234567890", false, "123456789", 0m, "27a510f7-a0ad-4c7e-84b1-26b751660ad8", false, "Admin" },
                    { new Guid("6bce7f0c-4460-4b56-b0c2-c1bca44db2d5"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fe82ed2d-8b3b-4709-988c-fa90debb4f7e", new DateTime(2022, 12, 7, 21, 43, 56, 315, DateTimeKind.Local).AddTicks(856), null, "2934827162", null, null, true, "Johnny", true, "Johnathan", true, null, "Doe", null, "JOHN", "AQAAAAEAACcQAAAAEEG31bDVgPY8eVsnZg7Jw0RBfSgUQntGLitLpAq5x2DvOxzRMxRPmtkGPzPaXWINqw==", "08923471624", false, "324123539", 9000m, "e02a17d2-e90a-4dd3-8ada-43ae3df1bda8", false, "John" }
                });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 43, 56, 305, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 43, 56, 305, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 43, 56, 305, DateTimeKind.Local).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 43, 56, 305, DateTimeKind.Local).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 43, 56, 305, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 43, 56, 305, DateTimeKind.Local).AddTicks(8507));

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Address", "ArrivalDate", "CheckedIn", "CreatedOn", "DeletedOn", "DepartureDate", "EditedOn", "GuestEmail", "GuestFirstName", "GuestLastName", "GuestNationality", "GuestPhoneNumber", "IsActive", "NumberOfChildren", "NumberOfGuests", "RoomId", "totalPrice" },
                values: new object[,]
                {
                    { "R72TSXV2", "Svishtov 532", new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), null, "gasgao@abv.bg", "Makaron", "Sharan", "Lujica", "247457452", true, 1, 2, 3, 1000m },
                    { "RFWSU6Q8", "Ararwaerawe st. 2", new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), null, "bachokiro@abv.bg", "Jogn", "Bonbon", "Ebnasdg", "43252352", true, 1, 2, 1, 300m },
                    { "ROATFZB7", "Berlinm st. 2", new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "aeiotawi@abv.bg", "Gorgon", "Maimun", "Etipiq", "432522342552", true, 1, 3, 4, 7000m },
                    { "RPD6746R", "Sofia 34 st. 2", new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "karakan@abv.bg", "Kapucin", "Krava", "Tigan", "4643453453352", true, 0, 2, 7, 3840m },
                    { "RPQF4POU", "Avenue 235 st. 2", new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), null, "bacro@abv.bg", "Alex", "Malex", "Bulgarian", "74572", true, 1, 5, 6, 3000m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2239660f-9cd7-40a5-8c95-a1041451b375"), new Guid("36fdc4d6-b4cc-4608-8f95-03c45b3c645f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("08b4f8c4-b864-4a53-a32e-06de1bc719ac"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0b2967c0-87f8-4634-8500-b6224f482bb7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("275f7748-cd52-48bb-8809-a84fa4f11e7e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("49533d2e-e49c-4f9c-aebd-4c2296a792ea"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f23493fb-e3c0-4cea-8404-9b79361291d4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f2e65074-9d5d-428b-8e33-917b11d323f5"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2239660f-9cd7-40a5-8c95-a1041451b375"), new Guid("36fdc4d6-b4cc-4608-8f95-03c45b3c645f") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bce7f0c-4460-4b56-b0c2-c1bca44db2d5"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "R72TSXV2");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "RFWSU6Q8");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "ROATFZB7");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "RPD6746R");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: "RPQF4POU");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2239660f-9cd7-40a5-8c95-a1041451b375"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36fdc4d6-b4cc-4608-8f95-03c45b3c645f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("03c7e9c8-991e-4cf5-b1dd-b89c8a0354f2"), "14042f4a-6d1c-4a66-be4e-eae60dc3a38f", "Front Desk", "FRONT DESK" },
                    { new Guid("08a5b7ee-10d8-4370-b08c-11e0c53563b0"), "8903752e-3e02-40e3-92f7-fe2aec052d9e", "Admin", "ADMIN" },
                    { new Guid("2da8c9bc-a563-4890-b6f6-f6466be822ad"), "3760389f-5722-4351-88ec-576c8ac3d3ec", "Owner", "OWNER" },
                    { new Guid("661824fc-5d6b-4348-914c-f9f2e1f30391"), "41637b26-7e52-4c64-a47f-76c5a3e6e440", "f&b", "F&B" },
                    { new Guid("d39021a4-ee63-46d6-a007-e76da5362392"), "0cf8b9cd-fbe1-4e1d-955d-77894fa7b07d", "Manager", "MANAGER" },
                    { new Guid("ea172e7f-ff07-49d0-976d-5f9e2b955da4"), "79152ae1-59cb-460c-84e6-136051b3cbad", "Human Resources", "HUMAN RESOURCES" },
                    { new Guid("f7ff6da8-0a7e-4c97-9554-8e5f006a8c4e"), "ae4d85ff-f699-4753-93ab-4ab468fdc16e", "Director", "DIRECTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "EGN", "EditedOn", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RFID", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0902201d-e2b8-4f3f-a165-cecf6df5cafe"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1a1ceba6-4bba-4392-90a8-93b2254be0e4", new DateTime(2022, 12, 7, 21, 21, 35, 389, DateTimeKind.Local).AddTicks(9041), null, "2934827162", null, null, true, "Johnny", true, "Johnathan", true, null, "Doe", null, "JOHN", "AQAAAAEAACcQAAAAENiMnXDru3FgaYajCt7GwnjDzIa3JshcYGNgXHlcNHLSN8dh8/ZubazrfKwYMYRK+A==", "08923471624", false, "324123539", 9000m, "7a3ffad7-a474-44e7-991e-650a109b5581", false, "John" },
                    { new Guid("2930464c-c435-40f4-a381-0bef0423f857"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8dab0342-44fe-4563-b924-5616f0ba8950", new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(5580), null, "123", null, null, true, "Admin", true, "Admin", false, null, "Admin", null, "ADMIN", "AQAAAAEAACcQAAAAEEk/lzt9IaacJqistG8cYBBGiJbf89NXPmIA0UD9ynmrW6eh5FDMwrl6ImRYw2wR9g==", "1234567890", false, "123456789", 0m, "04d93764-fb8a-43ca-8cd8-12d97e2477ee", false, "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 7, 21, 21, 35, 381, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Address", "ArrivalDate", "CheckedIn", "CreatedOn", "DeletedOn", "DepartureDate", "EditedOn", "GuestEmail", "GuestFirstName", "GuestLastName", "GuestNationality", "GuestPhoneNumber", "IsActive", "NumberOfChildren", "NumberOfGuests", "RoomId", "totalPrice" },
                values: new object[,]
                {
                    { "0a5b7675-4437-47e1-a614-6d58b6fda482", "Sofia 34 st. 2", new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "karakan@abv.bg", "Kapucin", "Krava", "Tigan", "4643453453352", true, 0, 2, 7, 3840m },
                    { "3b19b085-8df1-4157-95d7-3b0e2fc544fe", "Avenue 235 st. 2", new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), null, "bacro@abv.bg", "Alex", "Malex", "Bulgarian", "74572", true, 1, 5, 6, 3000m },
                    { "453b7f24-89a4-404e-91a0-67ef3ebe842c", "Berlinm st. 2", new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "aeiotawi@abv.bg", "Gorgon", "Maimun", "Etipiq", "432522342552", true, 1, 3, 4, 7000m },
                    { "993ecb0a-5618-4704-9ef3-3d0aeac37b4a", "Svishtov 532", new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), null, "gasgao@abv.bg", "Makaron", "Sharan", "Lujica", "247457452", true, 1, 2, 3, 1000m },
                    { "c5da5173-ec00-437a-bd07-7056c58ade1b", "Ararwaerawe st. 2", new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), null, "bachokiro@abv.bg", "Jogn", "Bonbon", "Ebnasdg", "43252352", true, 1, 2, 1, 300m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2da8c9bc-a563-4890-b6f6-f6466be822ad"), new Guid("2930464c-c435-40f4-a381-0bef0423f857") });
        }
    }
}

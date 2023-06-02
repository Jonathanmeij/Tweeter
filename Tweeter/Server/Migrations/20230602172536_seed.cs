using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tweeter.Server.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp", "UserName" },
                values: new object[] { "ad58899e-fde5-4d7e-bd70-c86603f09f9e", "johndoe@mail.com", "f542f1e2-f119-4bf6-9bdc-d3cafb2195dc", "johndoe" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { "1", "Hello World!", new DateTime(2023, 6, 2, 19, 25, 36, 201, DateTimeKind.Local).AddTicks(9020), new DateTime(2023, 6, 2, 19, 25, 36, 201, DateTimeKind.Local).AddTicks(9060), "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp", "UserName" },
                values: new object[] { "f307dd52-e73e-4a72-8dab-c81b400bee6b", "test@mail.com", "16200aca-49d5-4a99-8fda-90716882ca30", "test" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "71b28292-6b34-4c79-b6fa-da5d114b3a78", "johndoe@gmail.com", false, false, null, null, null, null, null, false, null, "1af6d466-3c9c-4bb3-8c0e-7ab901b2660b", false, "John Doe" });
        }
    }
}

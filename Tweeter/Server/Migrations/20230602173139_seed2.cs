using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tweeter.Server.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "e58ea8fb-26cf-46cf-8715-ab6047cb7231", "https://fastly.picsum.photos/id/204/400/400.jpg?hmac=KqqANeQnoq20mhaCP7hblGf_FWK85L30flhC_Zu5-tE", "80e6f451-0eac-4a8f-a383-dbf104fe41a2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "7e915f74-529d-41bb-ace9-b9739e0dee31", "kees@mail.com", false, false, null, null, null, null, null, false, "https://fastly.picsum.photos/id/130/400/400.jpg?hmac=t7pjDM3Xuw1JrVA6Zohl7DYlGQWzMGSx6Mo9n-rgQQY", "983f480f-37ee-4b0d-b87f-4ba916834489", false, "Kees" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 2, 19, 31, 39, 764, DateTimeKind.Local).AddTicks(9360), new DateTime(2023, 6, 2, 19, 31, 39, 764, DateTimeKind.Local).AddTicks(9400) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { "2", "Kees aan de kade", new DateTime(2023, 6, 2, 19, 31, 39, 764, DateTimeKind.Local).AddTicks(9410), new DateTime(2023, 6, 2, 19, 31, 39, 764, DateTimeKind.Local).AddTicks(9410), "2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "ad58899e-fde5-4d7e-bd70-c86603f09f9e", null, "f542f1e2-f119-4bf6-9bdc-d3cafb2195dc" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 2, 19, 25, 36, 201, DateTimeKind.Local).AddTicks(9020), new DateTime(2023, 6, 2, 19, 25, 36, 201, DateTimeKind.Local).AddTicks(9060) });
        }
    }
}

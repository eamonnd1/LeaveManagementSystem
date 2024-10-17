using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e9cdd4e-1f5e-4f4d-8d93-b02817356197", null, "Supervisor", "SUPERVISOR" },
                    { "3be49617-e2ca-40a0-9707-7f990df5a16c", null, "Employee", "EMPLOYEE" },
                    { "c732cc9b-14ca-43d7-bf3d-a67b31ae7c80", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5", 0, "d79e54fd-ea41-4b05-9bb8-eb40ec9439a4", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIhMmzdWgHJdeOQ6N542eUwns2hBSo70qRrGWb58DlRVmgQzr1YYkVuGFuRE5Q87jg==", null, false, "3108a04a-6f3f-4e02-82ff-23ff179f4c20", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c732cc9b-14ca-43d7-bf3d-a67b31ae7c80", "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e9cdd4e-1f5e-4f4d-8d93-b02817356197");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3be49617-e2ca-40a0-9707-7f990df5a16c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c732cc9b-14ca-43d7-bf3d-a67b31ae7c80", "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c732cc9b-14ca-43d7-bf3d-a67b31ae7c80");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5");
        }
    }
}

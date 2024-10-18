using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32adcaf6-36a6-4bae-8883-fd6d02f02822", new DateOnly(2000, 1, 1), "Default", "Admin", "AQAAAAIAAYagAAAAENP6MKr3QOWmn7JZ7VLQgoQDfIlhzaWYoG7CbVPHpzurPNRzYpX7DXf+acasdjNTxA==", "49c7d664-da9f-41b5-842b-84aa109825bc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d79e54fd-ea41-4b05-9bb8-eb40ec9439a4", "AQAAAAIAAYagAAAAEIhMmzdWgHJdeOQ6N542eUwns2hBSo70qRrGWb58DlRVmgQzr1YYkVuGFuRE5Q87jg==", "3108a04a-6f3f-4e02-82ff-23ff179f4c20" });
        }
    }
}

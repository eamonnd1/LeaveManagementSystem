using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLeaveRequestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_AspNetUsers_EmployeeId",
                table: "leaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_AspNetUsers_ReviewerId",
                table: "leaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_LeaveRequestStatuses_LeaveStatusId",
                table: "leaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_LeaveTypes_LeaveTypeId",
                table: "leaveRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_leaveRequests",
                table: "leaveRequests");

            migrationBuilder.DropColumn(
                name: "LeaveId",
                table: "leaveRequests");

            migrationBuilder.RenameTable(
                name: "leaveRequests",
                newName: "LeaveRequests");

            migrationBuilder.RenameIndex(
                name: "IX_leaveRequests_ReviewerId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_leaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_leaveRequests_LeaveStatusId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_LeaveStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_leaveRequests_EmployeeId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "LeaveTypeId",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6628e6fd-1677-4695-9ce3-eecd60f680bb", "AQAAAAIAAYagAAAAEFW+KT3AerczGcJoTI5GlzosDDjhNqEDWA6P8sMBSNHpoSj8BFPtRwtrRYUbKTRZxA==", "d1f6c851-5289-466f-a48c-d1ad0ce3bf91" });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_ReviewerId",
                table: "LeaveRequests",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveStatusId",
                table: "LeaveRequests",
                column: "LeaveStatusId",
                principalTable: "LeaveRequestStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_EmployeeId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_ReviewerId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveStatusId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                table: "LeaveRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests");

            migrationBuilder.RenameTable(
                name: "LeaveRequests",
                newName: "leaveRequests");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_ReviewerId",
                table: "leaveRequests",
                newName: "IX_leaveRequests_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "leaveRequests",
                newName: "IX_leaveRequests_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_LeaveStatusId",
                table: "leaveRequests",
                newName: "IX_leaveRequests_LeaveStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "leaveRequests",
                newName: "IX_leaveRequests_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "LeaveTypeId",
                table: "leaveRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LeaveId",
                table: "leaveRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_leaveRequests",
                table: "leaveRequests",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4425fd5f-facf-40fc-835a-a28efb52b0e1", "AQAAAAIAAYagAAAAEKnK5IS5hpdiNUKx96vfZ2hQ3dYaEeAO1rbxSEo5g8g49gFSrd3YP9Y/yh0hhEa6WQ==", "97ad11da-eb72-4ede-b58b-31b81364ef29" });

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_AspNetUsers_EmployeeId",
                table: "leaveRequests",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_AspNetUsers_ReviewerId",
                table: "leaveRequests",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_LeaveRequestStatuses_LeaveStatusId",
                table: "leaveRequests",
                column: "LeaveStatusId",
                principalTable: "LeaveRequestStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_LeaveTypes_LeaveTypeId",
                table: "leaveRequests",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id");
        }
    }
}

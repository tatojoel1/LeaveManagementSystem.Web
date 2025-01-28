using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56e74e41-c6fc-408f-957d-815e490b515f", new DateOnly(1992, 6, 11), "Joel", "Hernandez", "AQAAAAIAAYagAAAAEAZb/pglcV7NB8OxFkvxF3U6ZAjuz+tcDgTgJ7DMb95OqAOxepSvw5luCiNCIquxiQ==", "eb185ec9-534b-4c85-bef6-09a8e27de347" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22b13f3d-52a2-475b-bed7-a48ef6a90256", "AQAAAAIAAYagAAAAEJ30+nY8P1K4iMPseDWhcPNVYgd/ItYjWfF4YHubZHQLu7zLxtZRgTR6K/NZah3tFw==", "7ede5bcf-7fb8-41b6-bad8-6ace7ddc1d63" });
        }
    }
}

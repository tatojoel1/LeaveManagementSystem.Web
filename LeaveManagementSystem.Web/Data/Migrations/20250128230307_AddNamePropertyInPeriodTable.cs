using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddNamePropertyInPeriodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Periods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "054d1876-ed21-4f59-9d52-167ab7bee27c", "AQAAAAIAAYagAAAAEKWUMTnJ+RMEo2p2Rqoee41Z5q4L4HCzO86//or1pPBRuufaNVuBuRtgIpqINOcq+Q==", "ed28bda6-9e00-4469-92c2-a4d48c9a693e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Periods");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6769f376-2a89-4f9c-bd45-166e41662dd8", "AQAAAAIAAYagAAAAEEuPUFUcWCrzbDJDMff8KQAzkf5oiJPG4yAjH3xoN3xDh9ar/CDS6Fbhemmsms451w==", "f08fbdc0-09a1-475c-9c8a-87cf39028857" });
        }
    }
}

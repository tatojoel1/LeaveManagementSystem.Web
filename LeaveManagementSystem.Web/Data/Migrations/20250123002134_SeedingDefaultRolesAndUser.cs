using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2852ea1f-2066-4b70-9c6c-625addef42c5", null, "Employee", "EMPLOYEE" },
                    { "3a045307-297a-414c-b833-801d2717c0ee", null, "Supervisor", "SUPERVISOR" },
                    { "b02c3aef-9985-4eca-9283-77040111df04", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4", 0, "22b13f3d-52a2-475b-bed7-a48ef6a90256", "admin@localhost.com", true, false, null, "ADMIN@LOCAlHOST.COM", "ADMIN@LOCAlHOST.COM", "AQAAAAIAAYagAAAAEJ30+nY8P1K4iMPseDWhcPNVYgd/ItYjWfF4YHubZHQLu7zLxtZRgTR6K/NZah3tFw==", null, false, "7ede5bcf-7fb8-41b6-bad8-6ace7ddc1d63", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b02c3aef-9985-4eca-9283-77040111df04", "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2852ea1f-2066-4b70-9c6c-625addef42c5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3a045307-297a-414c-b833-801d2717c0ee");

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b02c3aef-9985-4eca-9283-77040111df04", "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b02c3aef-9985-4eca-9283-77040111df04");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddNewAdministrator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87635785-f793-4aa2-b57d-4da599e9a152", "AQAAAAIAAYagAAAAEF0cXqeMTDokA7vSgWoPjRTmPT/BgWhKMbflScBelOdtIadI0Js5d5UhsfP46I8gbg==", "edf73637-2f9e-4fd2-823a-b39f2b3d7489" });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b02c3aef-9985-4eca-9283-77040111df04", "6e08019a-d183-4095-9b34-3f933d35590f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b02c3aef-9985-4eca-9283-77040111df04", "6e08019a-d183-4095-9b34-3f933d35590f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56e74e41-c6fc-408f-957d-815e490b515f", "AQAAAAIAAYagAAAAEAZb/pglcV7NB8OxFkvxF3U6ZAjuz+tcDgTgJ7DMb95OqAOxepSvw5luCiNCIquxiQ==", "eb185ec9-534b-4c85-bef6-09a8e27de347" });
        }
    }
}

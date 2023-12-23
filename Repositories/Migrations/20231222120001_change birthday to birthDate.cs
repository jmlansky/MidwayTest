using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class changebirthdaytobirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Empleados_ResponsibleUPN",
                table: "Empleados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados");

            migrationBuilder.RenameTable(
                name: "Empleados",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Employees",
                newName: "BirthDate");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_ResponsibleUPN",
                table: "Employees",
                newName: "IX_Employees_ResponsibleUPN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "UPN");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ResponsibleUPN",
                table: "Employees",
                column: "ResponsibleUPN",
                principalTable: "Employees",
                principalColumn: "UPN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ResponsibleUPN",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Empleados");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Empleados",
                newName: "Birthday");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ResponsibleUPN",
                table: "Empleados",
                newName: "IX_Empleados_ResponsibleUPN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados",
                column: "UPN");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Empleados_ResponsibleUPN",
                table: "Empleados",
                column: "ResponsibleUPN",
                principalTable: "Empleados",
                principalColumn: "UPN");
        }
    }
}

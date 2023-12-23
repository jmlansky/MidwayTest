using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class employyfechaNacimientotobirthdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Empleados_ResponsableUPN",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "ResponsableUPN",
                table: "Empleados",
                newName: "ResponsibleUPN");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Empleados",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Empleados",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "Empleados",
                newName: "LastName");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_ResponsableUPN",
                table: "Empleados",
                newName: "IX_Empleados_ResponsibleUPN");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Empleados_ResponsibleUPN",
                table: "Empleados",
                column: "ResponsibleUPN",
                principalTable: "Empleados",
                principalColumn: "UPN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Empleados_ResponsibleUPN",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "ResponsibleUPN",
                table: "Empleados",
                newName: "ResponsableUPN");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Empleados",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Empleados",
                newName: "Apellidos");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Empleados",
                newName: "FechaNacimiento");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_ResponsibleUPN",
                table: "Empleados",
                newName: "IX_Empleados_ResponsableUPN");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Empleados_ResponsableUPN",
                table: "Empleados",
                column: "ResponsableUPN",
                principalTable: "Empleados",
                principalColumn: "UPN");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class userpk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Empleados_ResponsableId",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "ResponsableId",
                table: "Empleados",
                newName: "ResponsableUPN");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Empleados",
                newName: "UPN");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_ResponsableId",
                table: "Empleados",
                newName: "IX_Empleados_ResponsableUPN");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Empleados_ResponsableUPN",
                table: "Empleados",
                column: "ResponsableUPN",
                principalTable: "Empleados",
                principalColumn: "UPN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Empleados_ResponsableUPN",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "ResponsableUPN",
                table: "Empleados",
                newName: "ResponsableId");

            migrationBuilder.RenameColumn(
                name: "UPN",
                table: "Empleados",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_ResponsableUPN",
                table: "Empleados",
                newName: "IX_Empleados_ResponsableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Empleados_ResponsableId",
                table: "Empleados",
                column: "ResponsableId",
                principalTable: "Empleados",
                principalColumn: "Id");
        }
    }
}

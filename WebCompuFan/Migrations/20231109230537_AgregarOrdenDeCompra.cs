using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCompuFan.Migrations
{
    public partial class AgregarOrdenDeCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "OrdenDeCompra");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "OrdenDeCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "OrdenDeCompra");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "OrdenDeCompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

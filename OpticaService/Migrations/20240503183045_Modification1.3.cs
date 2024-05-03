using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaService.Migrations
{
    public partial class Modification13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Servicios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Opticos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Modelos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Marcas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Opticos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Clientes");
        }
    }
}

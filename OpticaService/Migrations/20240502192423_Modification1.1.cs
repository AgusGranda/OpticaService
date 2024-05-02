using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaService.Migrations
{
    public partial class Modification11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comentario",
                table: "Servicios",
                newName: "Descripcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Servicios",
                newName: "Comentario");
        }
    }
}

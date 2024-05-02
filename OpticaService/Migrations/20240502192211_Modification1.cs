using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaService.Migrations
{
    public partial class Modification1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Opticos");

            migrationBuilder.DropColumn(
                name: "HorarioLaboral",
                table: "Opticos");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Productos",
                newName: "Modelo_idId");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Productos",
                newName: "Proveedor");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Clientes",
                newName: "Telefono");

            migrationBuilder.AddColumn<int>(
                name: "Categoria_idId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Productos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCompra",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Marca_idId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioCompra",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ficha = table.Column<int>(type: "int", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Optico_idId = table.Column<int>(type: "int", nullable: false),
                    Cliente_idId = table.Column<int>(type: "int", nullable: false),
                    Producto_idId = table.Column<int>(type: "int", nullable: false),
                    Servicio_idId = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_Cliente_idId",
                        column: x => x.Cliente_idId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Opticos_Optico_idId",
                        column: x => x.Optico_idId,
                        principalTable: "Opticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Productos_Producto_idId",
                        column: x => x.Producto_idId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Servicios_Servicio_idId",
                        column: x => x.Servicio_idId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Categoria_idId",
                table: "Productos",
                column: "Categoria_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Marca_idId",
                table: "Productos",
                column: "Marca_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Modelo_idId",
                table: "Productos",
                column: "Modelo_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Cliente_idId",
                table: "Ventas",
                column: "Cliente_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Optico_idId",
                table: "Ventas",
                column: "Optico_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Producto_idId",
                table: "Ventas",
                column: "Producto_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Servicio_idId",
                table: "Ventas",
                column: "Servicio_idId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_Categoria_idId",
                table: "Productos",
                column: "Categoria_idId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_Marca_idId",
                table: "Productos",
                column: "Marca_idId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Modelos_Modelo_idId",
                table: "Productos",
                column: "Modelo_idId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_Categoria_idId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_Marca_idId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Modelos_Modelo_idId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Categoria_idId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Marca_idId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Modelo_idId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Categoria_idId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "FechaCompra",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Marca_idId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PrecioCompra",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Proveedor",
                table: "Productos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Modelo_idId",
                table: "Productos",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Clientes",
                newName: "Celular");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Celular",
                table: "Opticos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorarioLaboral",
                table: "Opticos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

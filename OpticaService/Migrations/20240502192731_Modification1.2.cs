using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaService.Migrations
{
    public partial class Modification12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_Cliente_idId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Opticos_Optico_idId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Productos_Producto_idId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Servicios_Servicio_idId",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "Servicio_idId",
                table: "Ventas",
                newName: "ServicioId");

            migrationBuilder.RenameColumn(
                name: "Producto_idId",
                table: "Ventas",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "Optico_idId",
                table: "Ventas",
                newName: "OpticoId");

            migrationBuilder.RenameColumn(
                name: "Cliente_idId",
                table: "Ventas",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_Servicio_idId",
                table: "Ventas",
                newName: "IX_Ventas_ServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_Producto_idId",
                table: "Ventas",
                newName: "IX_Ventas_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_Optico_idId",
                table: "Ventas",
                newName: "IX_Ventas_OpticoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_Cliente_idId",
                table: "Ventas",
                newName: "IX_Ventas_ClienteId");

            migrationBuilder.RenameColumn(
                name: "Modelo_idId",
                table: "Productos",
                newName: "ModeloId");

            migrationBuilder.RenameColumn(
                name: "Marca_idId",
                table: "Productos",
                newName: "MarcaId");

            migrationBuilder.RenameColumn(
                name: "Categoria_idId",
                table: "Productos",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_Modelo_idId",
                table: "Productos",
                newName: "IX_Productos_ModeloId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_Marca_idId",
                table: "Productos",
                newName: "IX_Productos_MarcaId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_Categoria_idId",
                table: "Productos",
                newName: "IX_Productos_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Modelos_ModeloId",
                table: "Productos",
                column: "ModeloId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Opticos_OpticoId",
                table: "Ventas",
                column: "OpticoId",
                principalTable: "Opticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Servicios_ServicioId",
                table: "Ventas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Modelos_ModeloId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Opticos_OpticoId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Servicios_ServicioId",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "ServicioId",
                table: "Ventas",
                newName: "Servicio_idId");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Ventas",
                newName: "Producto_idId");

            migrationBuilder.RenameColumn(
                name: "OpticoId",
                table: "Ventas",
                newName: "Optico_idId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Ventas",
                newName: "Cliente_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ServicioId",
                table: "Ventas",
                newName: "IX_Ventas_Servicio_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ProductoId",
                table: "Ventas",
                newName: "IX_Ventas_Producto_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_OpticoId",
                table: "Ventas",
                newName: "IX_Ventas_Optico_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                newName: "IX_Ventas_Cliente_idId");

            migrationBuilder.RenameColumn(
                name: "ModeloId",
                table: "Productos",
                newName: "Modelo_idId");

            migrationBuilder.RenameColumn(
                name: "MarcaId",
                table: "Productos",
                newName: "Marca_idId");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Productos",
                newName: "Categoria_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_ModeloId",
                table: "Productos",
                newName: "IX_Productos_Modelo_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                newName: "IX_Productos_Marca_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                newName: "IX_Productos_Categoria_idId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_Cliente_idId",
                table: "Ventas",
                column: "Cliente_idId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Opticos_Optico_idId",
                table: "Ventas",
                column: "Optico_idId",
                principalTable: "Opticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Productos_Producto_idId",
                table: "Ventas",
                column: "Producto_idId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Servicios_Servicio_idId",
                table: "Ventas",
                column: "Servicio_idId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

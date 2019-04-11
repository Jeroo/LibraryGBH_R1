using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryGBH.Data.Migrations
{
    public partial class Update011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventario_ProductosTienda_ProductosTiendaId",
                table: "Inventario");

            migrationBuilder.DropIndex(
                name: "IX_Inventario_ProductosTiendaId",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "ProductosTiendaId",
                table: "Inventario");

            migrationBuilder.AddColumn<long>(
                name: "InventarioId",
                table: "ProductosTienda",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosTienda_InventarioId",
                table: "ProductosTienda",
                column: "InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosTienda_Inventario_InventarioId",
                table: "ProductosTienda",
                column: "InventarioId",
                principalTable: "Inventario",
                principalColumn: "InventarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosTienda_Inventario_InventarioId",
                table: "ProductosTienda");

            migrationBuilder.DropIndex(
                name: "IX_ProductosTienda_InventarioId",
                table: "ProductosTienda");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "ProductosTienda");

            migrationBuilder.AddColumn<long>(
                name: "ProductoId",
                table: "Inventario",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductosTiendaId",
                table: "Inventario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_ProductosTiendaId",
                table: "Inventario",
                column: "ProductosTiendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventario_ProductosTienda_ProductosTiendaId",
                table: "Inventario",
                column: "ProductosTiendaId",
                principalTable: "ProductosTienda",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

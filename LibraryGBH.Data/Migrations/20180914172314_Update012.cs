using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryGBH.Data.Migrations
{
    public partial class Update012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosPool_ProductosTienda_ProductosTiendaId",
                table: "ProductosPool");

            migrationBuilder.DropIndex(
                name: "IX_ProductosPool_ProductosTiendaId",
                table: "ProductosPool");

            migrationBuilder.DropColumn(
                name: "ProductosTiendaId",
                table: "ProductosPool");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPool_ProductoId",
                table: "ProductosPool",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosPool_ProductosTienda_ProductoId",
                table: "ProductosPool",
                column: "ProductoId",
                principalTable: "ProductosTienda",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosPool_ProductosTienda_ProductoId",
                table: "ProductosPool");

            migrationBuilder.DropIndex(
                name: "IX_ProductosPool_ProductoId",
                table: "ProductosPool");

            migrationBuilder.AddColumn<long>(
                name: "ProductosTiendaId",
                table: "ProductosPool",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPool_ProductosTiendaId",
                table: "ProductosPool",
                column: "ProductosTiendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosPool_ProductosTienda_ProductosTiendaId",
                table: "ProductosPool",
                column: "ProductosTiendaId",
                principalTable: "ProductosTienda",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

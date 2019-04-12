using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryGBH.Data.Migrations
{
    public partial class DeleteDuplicity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "BookFormatId",
                table: "CONF_BooksPages");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "CONF_BooksPages");

            migrationBuilder.DropColumn(
                name: "BookTypeId",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "Pages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BookFormatId",
                table: "CONF_BooksPages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "CONF_BooksPages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BookTypeId",
                table: "Books",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

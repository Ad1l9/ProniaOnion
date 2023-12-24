using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaOnion.Persistence.Contexts.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Tags",
                newName: "IgnoreQuery");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductTags",
                newName: "IgnoreQuery");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "IgnoreQuery");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductColors",
                newName: "IgnoreQuery");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Colors",
                newName: "IgnoreQuery");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Categories",
                newName: "IgnoreQuery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IgnoreQuery",
                table: "Tags",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IgnoreQuery",
                table: "ProductTags",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IgnoreQuery",
                table: "Products",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IgnoreQuery",
                table: "ProductColors",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IgnoreQuery",
                table: "Colors",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IgnoreQuery",
                table: "Categories",
                newName: "IsDeleted");
        }
    }
}

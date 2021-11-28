using Microsoft.EntityFrameworkCore.Migrations;

namespace Farmerce.Migrations
{
    public partial class AddCategoryAddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryCatID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CatID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCatID",
                table: "Products",
                column: "CategoryCatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryCatID",
                table: "Products",
                column: "CategoryCatID",
                principalTable: "Category",
                principalColumn: "CatID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryCatID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryCatID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryCatID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

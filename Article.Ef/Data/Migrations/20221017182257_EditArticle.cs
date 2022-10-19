using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Article.Ef.Migrations
{
    public partial class EditArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Catagories_CatagoryId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CatagoryId",
                table: "Articles",
                newName: "CatigoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_CatagoryId",
                table: "Articles",
                newName: "IX_Articles_CatigoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Catagories_CatigoryId",
                table: "Articles",
                column: "CatigoryId",
                principalTable: "Catagories",
                principalColumn: "CatigoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Catagories_CatigoryId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CatigoryId",
                table: "Articles",
                newName: "CatagoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_CatigoryId",
                table: "Articles",
                newName: "IX_Articles_CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Catagories_CatagoryId",
                table: "Articles",
                column: "CatagoryId",
                principalTable: "Catagories",
                principalColumn: "CatigoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

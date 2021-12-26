using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje.Migrations
{
    public partial class commentFoodId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FoodId",
                table: "Comments",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Foods_FoodId",
                table: "Comments",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Foods_FoodId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_FoodId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Comments");
        }
    }
}

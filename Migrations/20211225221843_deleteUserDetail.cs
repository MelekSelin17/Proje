using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje.Migrations
{
    public partial class deleteUserDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserDetails_UserDetailId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_UserDetails_UserDetailId",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserDetailId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserDetailId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserDetailId",
                table: "Likes",
                column: "UserDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserDetailId",
                table: "Comments",
                column: "UserDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserDetails_UserDetailId",
                table: "Comments",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_UserDetails_UserDetailId",
                table: "Likes",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

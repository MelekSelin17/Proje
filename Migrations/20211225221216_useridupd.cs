using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje.Migrations
{
    public partial class useridupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_AspNetUsers_UsersId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UsersId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "UserDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "UserDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UsersId",
                table: "UserDetails",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_AspNetUsers_UsersId",
                table: "UserDetails",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

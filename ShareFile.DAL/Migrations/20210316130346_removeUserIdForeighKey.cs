using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareFile.DAL.Migrations
{
    public partial class removeUserIdForeighKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessTokens_Users_SharedFileUserUserId",
                table: "AccessTokens");

            migrationBuilder.DropIndex(
                name: "IX_AccessTokens_SharedFileUserUserId",
                table: "AccessTokens");

            migrationBuilder.DropColumn(
                name: "SharedFileUserUserId",
                table: "AccessTokens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccessTokens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SharedFileUserUserId",
                table: "AccessTokens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AccessTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccessTokens_SharedFileUserUserId",
                table: "AccessTokens",
                column: "SharedFileUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessTokens_Users_SharedFileUserUserId",
                table: "AccessTokens",
                column: "SharedFileUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

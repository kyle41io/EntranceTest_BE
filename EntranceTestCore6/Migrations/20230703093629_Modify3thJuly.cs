using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntranceTestCore6.Migrations
{
    /// <inheritdoc />
    public partial class Modify3thJuly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAttempts_AspNetUsers_Email",
                table: "TestAttempts");

            migrationBuilder.DropIndex(
                name: "IX_TestAttempts_Email",
                table: "TestAttempts");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TestAttempts",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_ApplicationUserId",
                table: "TestAttempts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAttempts_AspNetUsers_ApplicationUserId",
                table: "TestAttempts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAttempts_AspNetUsers_ApplicationUserId",
                table: "TestAttempts");

            migrationBuilder.DropIndex(
                name: "IX_TestAttempts_ApplicationUserId",
                table: "TestAttempts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TestAttempts");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_Email",
                table: "TestAttempts",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAttempts_AspNetUsers_Email",
                table: "TestAttempts",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

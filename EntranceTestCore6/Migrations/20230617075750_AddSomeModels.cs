using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntranceTestCore6.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestListModel",
                columns: table => new
                {
                    TestName = table.Column<string>(type: "text", nullable: false),
                    TestTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TestDesc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestListModel", x => x.TestName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestAttemptLists_Email",
                table: "TestAttemptLists",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionLists_TestId",
                table: "QuestionLists",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionLists_TestLists_TestId",
                table: "QuestionLists",
                column: "TestId",
                principalTable: "TestLists",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAttemptLists_AspNetUsers_Email",
                table: "TestAttemptLists",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionLists_TestLists_TestId",
                table: "QuestionLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAttemptLists_AspNetUsers_Email",
                table: "TestAttemptLists");

            migrationBuilder.DropTable(
                name: "TestListModel");

            migrationBuilder.DropIndex(
                name: "IX_TestAttemptLists_Email",
                table: "TestAttemptLists");

            migrationBuilder.DropIndex(
                name: "IX_QuestionLists_TestId",
                table: "QuestionLists");
        }
    }
}

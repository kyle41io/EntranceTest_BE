using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntranceTestCore6.Migrations
{
    /// <inheritdoc />
    public partial class ChangeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAttemptLists_AspNetUsers_Email",
                table: "TestAttemptLists");

            migrationBuilder.DropTable(
                name: "TestListModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestQuestionAttemptLists",
                table: "TestQuestionAttemptLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAttemptLists",
                table: "TestAttemptLists");

            migrationBuilder.RenameTable(
                name: "TestQuestionAttemptLists",
                newName: "TestQuestionAttempts");

            migrationBuilder.RenameTable(
                name: "TestAttemptLists",
                newName: "TestAttempts");

            migrationBuilder.RenameIndex(
                name: "IX_TestAttemptLists_Email",
                table: "TestAttempts",
                newName: "IX_TestAttempts_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestQuestionAttempts",
                table: "TestQuestionAttempts",
                column: "AttemptQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAttempts",
                table: "TestAttempts",
                column: "AttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAttempts_AspNetUsers_Email",
                table: "TestAttempts",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAttempts_AspNetUsers_Email",
                table: "TestAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestQuestionAttempts",
                table: "TestQuestionAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAttempts",
                table: "TestAttempts");

            migrationBuilder.RenameTable(
                name: "TestQuestionAttempts",
                newName: "TestQuestionAttemptLists");

            migrationBuilder.RenameTable(
                name: "TestAttempts",
                newName: "TestAttemptLists");

            migrationBuilder.RenameIndex(
                name: "IX_TestAttempts_Email",
                table: "TestAttemptLists",
                newName: "IX_TestAttemptLists_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestQuestionAttemptLists",
                table: "TestQuestionAttemptLists",
                column: "AttemptQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAttemptLists",
                table: "TestAttemptLists",
                column: "AttemptId");

            migrationBuilder.CreateTable(
                name: "TestListModel",
                columns: table => new
                {
                    TestName = table.Column<string>(type: "text", nullable: false),
                    TestDesc = table.Column<string>(type: "text", nullable: false),
                    TestTime = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestListModel", x => x.TestName);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TestAttemptLists_AspNetUsers_Email",
                table: "TestAttemptLists",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

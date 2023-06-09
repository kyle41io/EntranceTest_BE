using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntranceTestCore6.Migrations
{
    /// <inheritdoc />
    public partial class AddModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionLists_TestLists_TestId",
                table: "QuestionLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAttemptLists_TestLists_TestId",
                table: "TestAttemptLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestionAttemptLists_QuestionLists_QuestionId",
                table: "TestQuestionAttemptLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestionAttemptLists_TestAttemptLists_AttemptId",
                table: "TestQuestionAttemptLists");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestionAttemptLists_AttemptId",
                table: "TestQuestionAttemptLists");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestionAttemptLists_QuestionId",
                table: "TestQuestionAttemptLists");

            migrationBuilder.DropIndex(
                name: "IX_TestAttemptLists_TestId",
                table: "TestAttemptLists");

            migrationBuilder.DropIndex(
                name: "IX_QuestionLists_TestId",
                table: "QuestionLists");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "TestAttemptLists");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TestAttemptLists",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "TestAttemptLists");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "TestAttemptLists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestionAttemptLists_AttemptId",
                table: "TestQuestionAttemptLists",
                column: "AttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestionAttemptLists_QuestionId",
                table: "TestQuestionAttemptLists",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttemptLists_TestId",
                table: "TestAttemptLists",
                column: "TestId");

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
                name: "FK_TestAttemptLists_TestLists_TestId",
                table: "TestAttemptLists",
                column: "TestId",
                principalTable: "TestLists",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestionAttemptLists_QuestionLists_QuestionId",
                table: "TestQuestionAttemptLists",
                column: "QuestionId",
                principalTable: "QuestionLists",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestionAttemptLists_TestAttemptLists_AttemptId",
                table: "TestQuestionAttemptLists",
                column: "AttemptId",
                principalTable: "TestAttemptLists",
                principalColumn: "AttemptId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

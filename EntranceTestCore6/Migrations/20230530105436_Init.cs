using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntranceTestCore6.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    SignUpDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TestAmount = table.Column<int>(type: "integer", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "TestLists",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestName = table.Column<string>(type: "text", nullable: true),
                    QuestionAmount = table.Column<int>(type: "integer", nullable: false),
                    TestTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TestDesc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestLists", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionLists",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    TestName = table.Column<string>(type: "text", nullable: true),
                    Question = table.Column<string>(type: "text", nullable: true),
                    Answer1 = table.Column<string>(type: "text", nullable: true),
                    Answer2 = table.Column<string>(type: "text", nullable: true),
                    Answer3 = table.Column<string>(type: "text", nullable: true),
                    Answer4 = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionLists", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_QuestionLists_TestLists_TestId",
                        column: x => x.TestId,
                        principalTable: "TestLists",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestAttemptLists",
                columns: table => new
                {
                    AttemptId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    TestName = table.Column<string>(type: "text", nullable: true),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TestAmount = table.Column<int>(type: "integer", nullable: false),
                    AmountCorrect = table.Column<int>(type: "integer", nullable: false),
                    IsFinish = table.Column<bool>(type: "boolean", nullable: false),
                    Accurate = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAttemptLists", x => x.AttemptId);
                    table.ForeignKey(
                        name: "FK_TestAttemptLists_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAttemptLists_TestLists_TestId",
                        column: x => x.TestId,
                        principalTable: "TestLists",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestionAttemptLists",
                columns: table => new
                {
                    AttemptQuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttemptId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    Chose = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswer = table.Column<int>(type: "integer", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestionAttemptLists", x => x.AttemptQuestionId);
                    table.ForeignKey(
                        name: "FK_TestQuestionAttemptLists_QuestionLists_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionLists",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestQuestionAttemptLists_TestAttemptLists_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "TestAttemptLists",
                        principalColumn: "AttemptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionLists_TestId",
                table: "QuestionLists",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttemptLists_MemberId",
                table: "TestAttemptLists",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttemptLists_TestId",
                table: "TestAttemptLists",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestionAttemptLists_AttemptId",
                table: "TestQuestionAttemptLists",
                column: "AttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestionAttemptLists_QuestionId",
                table: "TestQuestionAttemptLists",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestQuestionAttemptLists");

            migrationBuilder.DropTable(
                name: "QuestionLists");

            migrationBuilder.DropTable(
                name: "TestAttemptLists");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "TestLists");
        }
    }
}

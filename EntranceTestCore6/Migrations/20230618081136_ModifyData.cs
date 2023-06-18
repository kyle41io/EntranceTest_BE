using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntranceTestCore6.Migrations
{
    /// <inheritdoc />
    public partial class ModifyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionLists");

            migrationBuilder.DropTable(
                name: "TestLists");

            migrationBuilder.CreateTable(
                name: "Tests",
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
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    TestName = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Answer1 = table.Column<string>(type: "text", nullable: true),
                    Answer2 = table.Column<string>(type: "text", nullable: true),
                    Answer3 = table.Column<string>(type: "text", nullable: true),
                    Answer4 = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.CreateTable(
                name: "TestLists",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionAmount = table.Column<int>(type: "integer", nullable: false),
                    TestDesc = table.Column<string>(type: "text", nullable: true),
                    TestName = table.Column<string>(type: "text", nullable: true),
                    TestTime = table.Column<TimeSpan>(type: "interval", nullable: false)
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
                    Answer1 = table.Column<string>(type: "text", nullable: true),
                    Answer2 = table.Column<string>(type: "text", nullable: true),
                    Answer3 = table.Column<string>(type: "text", nullable: true),
                    Answer4 = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<int>(type: "integer", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: true),
                    TestName = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_QuestionLists_TestId",
                table: "QuestionLists",
                column: "TestId");
        }
    }
}

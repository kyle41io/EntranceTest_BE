using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntranceTestCore6.Migrations
{
    /// <inheritdoc />
    public partial class Modify26June2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionAmount",
                table: "Tests",
                newName: "TestTime");

            migrationBuilder.AddColumn<int>(
                name: "TestAmount",
                table: "Tests",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestAmount",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "TestTime",
                table: "Tests",
                newName: "QuestionAmount");
        }
    }
}

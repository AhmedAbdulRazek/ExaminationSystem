using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addQuestionTypeTAble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionType",
                table: "Questions",
                newName: "QuestionTypeId");

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionTypes_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId",
                principalTable: "QuestionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionTypes_QuestionTypeId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuestionTypeId",
                table: "Questions",
                newName: "QuestionType");
        }
    }
}

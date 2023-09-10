using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addMarkProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mark",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Questions");
        }
    }
}

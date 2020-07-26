using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlPlu.Questionnaire.Infrastructure.Migrations
{
    public partial class removeTitleFromForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Form");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Form",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Form",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

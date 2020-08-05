using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlPlu.Questionnaire.Infrastructure.Migrations
{
    public partial class AddingOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Form",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Form",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "FieldOptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Field",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "FieldOptions");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Field");
        }
    }
}

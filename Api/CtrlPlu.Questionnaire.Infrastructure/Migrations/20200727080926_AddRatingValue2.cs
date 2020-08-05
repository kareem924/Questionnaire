using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlPlu.Questionnaire.Infrastructure.Migrations
{
    public partial class AddRatingValue2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldId1",
                table: "RatingValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldId1",
                table: "RatingValue",
                type: "int",
                nullable: true);
        }
    }
}

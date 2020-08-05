using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlPlu.Questionnaire.Infrastructure.Migrations
{
    public partial class AddRatingValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    From = table.Column<int>(nullable: false),
                    To = table.Column<int>(nullable: false),
                    FromLabel = table.Column<string>(nullable: true),
                    ToLabel = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingValue_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RatingValue_FieldId",
                table: "RatingValue",
                column: "FieldId",
                unique: true,
                filter: "[FieldId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingValue");
        }
    }
}

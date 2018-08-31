using Microsoft.EntityFrameworkCore.Migrations;

namespace gamerpilotPlatform.Migrations
{
    public partial class addedIntro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseIntroductionId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseLength",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LifeSkill",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseIntroductions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseIntroductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LearningGoals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Goal = table.Column<string>(nullable: true),
                    CourseIntroductionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningGoals_CourseIntroductions_CourseIntroductionId",
                        column: x => x.CourseIntroductionId,
                        principalTable: "CourseIntroductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseIntroductionId",
                table: "Lectures",
                column: "CourseIntroductionId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningGoals_CourseIntroductionId",
                table: "LearningGoals",
                column: "CourseIntroductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_CourseIntroductions_CourseIntroductionId",
                table: "Lectures",
                column: "CourseIntroductionId",
                principalTable: "CourseIntroductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_CourseIntroductions_CourseIntroductionId",
                table: "Lectures");

            migrationBuilder.DropTable(
                name: "LearningGoals");

            migrationBuilder.DropTable(
                name: "CourseIntroductions");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CourseIntroductionId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CourseIntroductionId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CourseLength",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LifeSkill",
                table: "Courses");
        }
    }
}

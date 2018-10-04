using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gamerpilotPlatform.Migrations
{
    public partial class questionAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_CourseUsers_CourseUserUserId_CourseUserCourseId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_CourseUserUserId_CourseUserCourseId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CourseUserCourseId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CourseUserUserId",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "UserChoiceId",
                table: "Answers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "QuizAttemptId",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuizAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseUserCourseId = table.Column<string>(nullable: true),
                    CourseUserUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAttempts_CourseUsers_CourseUserUserId_CourseUserCourseId",
                        columns: x => new { x.CourseUserUserId, x.CourseUserCourseId },
                        principalTable: "CourseUsers",
                        principalColumns: new[] { "UserId", "CourseId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuizAttemptId",
                table: "Answers",
                column: "QuizAttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_CourseUserUserId_CourseUserCourseId",
                table: "QuizAttempts",
                columns: new[] { "CourseUserUserId", "CourseUserCourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuizAttempts_QuizAttemptId",
                table: "Answers",
                column: "QuizAttemptId",
                principalTable: "QuizAttempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuizAttempts_QuizAttemptId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "QuizAttempts");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuizAttemptId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuizAttemptId",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "UserChoiceId",
                table: "Answers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseUserCourseId",
                table: "Answers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseUserUserId",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CourseUserUserId_CourseUserCourseId",
                table: "Answers",
                columns: new[] { "CourseUserUserId", "CourseUserCourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_CourseUsers_CourseUserUserId_CourseUserCourseId",
                table: "Answers",
                columns: new[] { "CourseUserUserId", "CourseUserCourseId" },
                principalTable: "CourseUsers",
                principalColumns: new[] { "UserId", "CourseId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gamerpilotPlatform.Migrations
{
    public partial class addedfeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "CourseUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    LikelyToRecommend = table.Column<int>(nullable: false),
                    UniqueCourseOpinion = table.Column<string>(nullable: true),
                    WouldPayOpinion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseUsers_FeedbackId",
                table: "CourseUsers",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUsers_Feedback_FeedbackId",
                table: "CourseUsers",
                column: "FeedbackId",
                principalTable: "Feedback",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUsers_Feedback_FeedbackId",
                table: "CourseUsers");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_CourseUsers_FeedbackId",
                table: "CourseUsers");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "CourseUsers");
        }
    }
}

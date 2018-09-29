using Microsoft.EntityFrameworkCore.Migrations;

namespace gamerpilotPlatform.Migrations
{
    public partial class addedfeedbacktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUsers_Feedback_FeedbackId",
                table: "CourseUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Feedbacks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUsers_Feedbacks_FeedbackId",
                table: "CourseUsers",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUsers_Feedbacks_FeedbackId",
                table: "CourseUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "Feedback");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUsers_Feedback_FeedbackId",
                table: "CourseUsers",
                column: "FeedbackId",
                principalTable: "Feedback",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

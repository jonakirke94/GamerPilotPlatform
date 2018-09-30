using Microsoft.EntityFrameworkCore.Migrations;

namespace gamerpilotPlatform.Migrations
{
    public partial class addedforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUsers_Feedbacks_FeedbackId",
                table: "CourseUsers");

            migrationBuilder.AlterColumn<int>(
                name: "FeedbackId",
                table: "CourseUsers",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "FeedbackId",
                table: "CourseUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUsers_Feedbacks_FeedbackId",
                table: "CourseUsers",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gamerpilotPlatform.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "Courses",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            Name = table.Column<string>(nullable: true),
        //            UrlName = table.Column<string>(nullable: true),
        //            Description = table.Column<string>(nullable: true),
        //            ImageUrl = table.Column<string>(nullable: true),
        //            IsReleased = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Courses", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Feedbacks",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Rating = table.Column<int>(nullable: false),
        //            LikelyToRecommend = table.Column<int>(nullable: false),
        //            UniqueCourseOpinion = table.Column<string>(nullable: false),
        //            WouldPayOpinion = table.Column<string>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Feedbacks", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Instructors",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Instructors", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            Email = table.Column<string>(nullable: false),
        //            Username = table.Column<string>(nullable: false),
        //            Password = table.Column<string>(nullable: false),
        //            RefreshToken = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Lectures",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(nullable: true),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            Section = table.Column<int>(nullable: false),
        //            LectureType = table.Column<int>(nullable: false),
        //            InstructorId = table.Column<int>(nullable: true),
        //            CourseId = table.Column<string>(nullable: true),
        //            Discriminator = table.Column<string>(nullable: false),
        //            Description = table.Column<string>(nullable: true),
        //            CourseExercise_Description = table.Column<string>(nullable: true),
        //            Level = table.Column<string>(nullable: true),
        //            CourseLength = table.Column<string>(nullable: true),
        //            Language = table.Column<string>(nullable: true),
        //            LifeSkill = table.Column<string>(nullable: true),
        //            CourseIntroduction_Description = table.Column<string>(nullable: true),
        //            Summary = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Lectures", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Lectures_Courses_CourseId",
        //                column: x => x.CourseId,
        //                principalTable: "Courses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Lectures_Instructors_InstructorId",
        //                column: x => x.InstructorId,
        //                principalTable: "Instructors",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CourseUsers",
        //        columns: table => new
        //        {
        //            UserId = table.Column<string>(nullable: false),
        //            CourseId = table.Column<string>(nullable: false),
        //            IsCompleted = table.Column<bool>(nullable: false),
        //            EnrolledAt = table.Column<DateTime>(nullable: false),
        //            FeedbackId = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CourseUsers", x => new { x.UserId, x.CourseId });
        //            table.ForeignKey(
        //                name: "FK_CourseUsers_Courses_CourseId",
        //                column: x => x.CourseId,
        //                principalTable: "Courses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_CourseUsers_Feedbacks_FeedbackId",
        //                column: x => x.FeedbackId,
        //                principalTable: "Feedbacks",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_CourseUsers_Users_UserId",
        //                column: x => x.UserId,
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CaseSections",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            Title = table.Column<string>(nullable: true),
        //            Body = table.Column<string>(nullable: true),
        //            CourseCaseId = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CaseSections", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_CaseSections_Lectures_CourseCaseId",
        //                column: x => x.CourseCaseId,
        //                principalTable: "Lectures",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Exercises",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            Description = table.Column<string>(nullable: true),
        //            IsRealLife = table.Column<bool>(nullable: false),
        //            CourseExerciseId = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Exercises", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Exercises_Lectures_CourseExerciseId",
        //                column: x => x.CourseExerciseId,
        //                principalTable: "Lectures",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LearningGoals",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            Goal = table.Column<string>(nullable: true),
        //            CourseIntroductionId = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LearningGoals", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_LearningGoals_Lectures_CourseIntroductionId",
        //                column: x => x.CourseIntroductionId,
        //                principalTable: "Lectures",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Questions",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            Difficulty = table.Column<string>(nullable: true),
        //            QuestionText = table.Column<string>(nullable: true),
        //            CourseQuizId = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Questions", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Questions_Lectures_CourseQuizId",
        //                column: x => x.CourseQuizId,
        //                principalTable: "Lectures",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CompletedLectures",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            LectureId = table.Column<int>(nullable: false),
        //            CourseUserCourseId = table.Column<string>(nullable: true),
        //            CourseUserUserId = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CompletedLectures", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_CompletedLectures_CourseUsers_CourseUserUserId_CourseUserCourseId",
        //                columns: x => new { x.CourseUserUserId, x.CourseUserCourseId },
        //                principalTable: "CourseUsers",
        //                principalColumns: new[] { "UserId", "CourseId" },
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "QuizAttempts",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            SubmissionTime = table.Column<DateTime>(nullable: false),
        //            CourseUserCourseId = table.Column<string>(nullable: true),
        //            CourseUserUserId = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_QuizAttempts", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_QuizAttempts_CourseUsers_CourseUserUserId_CourseUserCourseId",
        //                columns: x => new { x.CourseUserUserId, x.CourseUserCourseId },
        //                principalTable: "CourseUsers",
        //                principalColumns: new[] { "UserId", "CourseId" },
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Choices",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Text = table.Column<string>(nullable: true),
        //            IsCorrect = table.Column<bool>(nullable: false),
        //            QuestionId = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Choices", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Choices_Questions_QuestionId",
        //                column: x => x.QuestionId,
        //                principalTable: "Questions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Answers",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            UserChoiceId = table.Column<int>(nullable: false),
        //            QuizAttemptId = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Answers", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Answers_QuizAttempts_QuizAttemptId",
        //                column: x => x.QuizAttemptId,
        //                principalTable: "QuizAttempts",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Answers_QuizAttemptId",
        //        table: "Answers",
        //        column: "QuizAttemptId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CaseSections_CourseCaseId",
        //        table: "CaseSections",
        //        column: "CourseCaseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Choices_QuestionId",
        //        table: "Choices",
        //        column: "QuestionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CompletedLectures_CourseUserUserId_CourseUserCourseId",
        //        table: "CompletedLectures",
        //        columns: new[] { "CourseUserUserId", "CourseUserCourseId" });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CourseUsers_CourseId",
        //        table: "CourseUsers",
        //        column: "CourseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CourseUsers_FeedbackId",
        //        table: "CourseUsers",
        //        column: "FeedbackId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Exercises_CourseExerciseId",
        //        table: "Exercises",
        //        column: "CourseExerciseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LearningGoals_CourseIntroductionId",
        //        table: "LearningGoals",
        //        column: "CourseIntroductionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Lectures_CourseId",
        //        table: "Lectures",
        //        column: "CourseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Lectures_InstructorId",
        //        table: "Lectures",
        //        column: "InstructorId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Questions_CourseQuizId",
        //        table: "Questions",
        //        column: "CourseQuizId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuizAttempts_CourseUserUserId_CourseUserCourseId",
        //        table: "QuizAttempts",
        //        columns: new[] { "CourseUserUserId", "CourseUserCourseId" });
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "Answers");

        //    migrationBuilder.DropTable(
        //        name: "CaseSections");

        //    migrationBuilder.DropTable(
        //        name: "Choices");

        //    migrationBuilder.DropTable(
        //        name: "CompletedLectures");

        //    migrationBuilder.DropTable(
        //        name: "Exercises");

        //    migrationBuilder.DropTable(
        //        name: "LearningGoals");

        //    migrationBuilder.DropTable(
        //        name: "QuizAttempts");

        //    migrationBuilder.DropTable(
        //        name: "Questions");

        //    migrationBuilder.DropTable(
        //        name: "CourseUsers");

        //    migrationBuilder.DropTable(
        //        name: "Lectures");

        //    migrationBuilder.DropTable(
        //        name: "Feedbacks");

        //    migrationBuilder.DropTable(
        //        name: "Users");

        //    migrationBuilder.DropTable(
        //        name: "Courses");

        //    migrationBuilder.DropTable(
        //        name: "Instructors");
        }
    }
}

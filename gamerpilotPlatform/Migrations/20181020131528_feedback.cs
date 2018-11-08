using Microsoft.EntityFrameworkCore.Migrations;

namespace gamerpilotPlatform.Migrations
{
    public partial class feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WouldPayOpinion",
                table: "Feedbacks");

            migrationBuilder.AddColumn<bool>(
                name: "DifferentFromYoutube",
                table: "Feedbacks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HowMuch",
                table: "Feedbacks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "WillingToPay",
                table: "Feedbacks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeResponse",
                table: "Feedbacks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifferentFromYoutube",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "HowMuch",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "WillingToPay",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "YoutubeResponse",
                table: "Feedbacks");

            migrationBuilder.AddColumn<string>(
                name: "WouldPayOpinion",
                table: "Feedbacks",
                nullable: false,
                defaultValue: "");
        }
    }
}

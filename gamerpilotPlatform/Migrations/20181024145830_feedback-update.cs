using Microsoft.EntityFrameworkCore.Migrations;

namespace gamerpilotPlatform.Migrations
{
    public partial class feedbackupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WillingToPay",
                table: "Feedbacks",
                newName: "InterestedInMore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InterestedInMore",
                table: "Feedbacks",
                newName: "WillingToPay");
        }
    }
}

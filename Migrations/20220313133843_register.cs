using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImagePath",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ProfileImagePath",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "BusinessName",
                table: "Businesses",
                newName: "businessName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "businessName",
                table: "Businesses",
                newName: "BusinessName");

            migrationBuilder.AddColumn<string>(
                name: "CoverImagePath",
                table: "Accounts",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImagePath",
                table: "Accounts",
                type: "nvarchar(250)",
                nullable: true);
        }
    }
}

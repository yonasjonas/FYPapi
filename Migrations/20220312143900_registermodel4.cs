using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class registermodel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profileImagePath",
                table: "Accounts",
                newName: "ProfileImagePath");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Accounts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "coverImagePath",
                table: "Accounts",
                newName: "CoverImagePath");

            migrationBuilder.RenameColumn(
                name: "county",
                table: "Accounts",
                newName: "County");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Accounts",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "address2",
                table: "Accounts",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "address1",
                table: "Accounts",
                newName: "Address1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImagePath",
                table: "Accounts",
                newName: "profileImagePath");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Accounts",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CoverImagePath",
                table: "Accounts",
                newName: "coverImagePath");

            migrationBuilder.RenameColumn(
                name: "County",
                table: "Accounts",
                newName: "county");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Accounts",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "Accounts",
                newName: "address2");

            migrationBuilder.RenameColumn(
                name: "Address1",
                table: "Accounts",
                newName: "address1");
        }
    }
}

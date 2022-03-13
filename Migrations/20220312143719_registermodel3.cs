using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class registermodel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Accounts",
                newName: "profileImagePath");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Accounts",
                newName: "coverImagePath");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Accounts",
                newName: "county");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "Accounts",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Accounts",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address1",
                table: "Accounts",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address2",
                table: "Accounts",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Accounts",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Accounts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "address1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "address2",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "country",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "profileImagePath",
                table: "Accounts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "coverImagePath",
                table: "Accounts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "county",
                table: "Accounts",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Accounts",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }
    }
}

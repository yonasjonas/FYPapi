using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class allmaintable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "activated",
                table: "BusinessManager",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "boolean");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "activated",
                table: "BusinessManager",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}

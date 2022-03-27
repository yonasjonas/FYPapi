using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class modifiedbookingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "businessId",
                table: "Booking",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "serviceId",
                table: "Booking",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "businessName",
                table: "Booking",
                newName: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "BookingDuration",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BookingStartTime",
                table: "Booking",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Booking",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Booking",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDuration",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "BookingStartTime",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Booking",
                newName: "businessId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Booking",
                newName: "serviceId");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Booking",
                newName: "businessName");

            migrationBuilder.AddColumn<string>(
                name: "date",
                table: "Booking",
                type: "nvarchar(250)",
                nullable: true);
        }
    }
}

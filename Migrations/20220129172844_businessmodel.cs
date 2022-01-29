using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class businessmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    locationName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    businessCategory = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    imagePath = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    priceRange = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}

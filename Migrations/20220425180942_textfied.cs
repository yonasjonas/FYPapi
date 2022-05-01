﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class textfied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "BusinessInfo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "BusinessInfo",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}

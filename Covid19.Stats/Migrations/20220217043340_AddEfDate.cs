using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Stats.Migrations
{
    public partial class AddEfDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date2",
                table: "Stats",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Update2",
                table: "Stats",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date2",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Last_Update2",
                table: "Stats");
        }
    }
}

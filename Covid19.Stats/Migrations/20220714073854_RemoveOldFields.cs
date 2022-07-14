using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Stats.Migrations
{
    public partial class RemoveOldFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin2",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Date_Seconds",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "FIPS",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Last_Update_Seconds",
                table: "Stats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Admin2",
                table: "Stats",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Date_Seconds",
                table: "Stats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FIPS",
                table: "Stats",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Last_Update_Seconds",
                table: "Stats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

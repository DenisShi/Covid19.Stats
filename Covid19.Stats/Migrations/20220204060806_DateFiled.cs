using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Stats.Migrations
{
    public partial class DateFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Stats");

            migrationBuilder.RenameColumn(
                name: "ProvinceState",
                table: "Stats",
                newName: "Province_State");

            migrationBuilder.RenameColumn(
                name: "Deaths",
                table: "Stats",
                newName: "Last_Update");

            migrationBuilder.RenameColumn(
                name: "CountryRegion",
                table: "Stats",
                newName: "FIPS");

            migrationBuilder.AddColumn<string>(
                name: "Admin2",
                table: "Stats",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Case_Fatality_Ratio",
                table: "Stats",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Combined_key",
                table: "Stats",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country_Region",
                table: "Stats",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Date",
                table: "Stats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Death",
                table: "Stats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Incident_Rate",
                table: "Stats",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Lat",
                table: "Stats",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Long",
                table: "Stats",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin2",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Case_Fatality_Ratio",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Combined_key",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Country_Region",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Death",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Incident_Rate",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Stats");

            migrationBuilder.RenameColumn(
                name: "Province_State",
                table: "Stats",
                newName: "ProvinceState");

            migrationBuilder.RenameColumn(
                name: "Last_Update",
                table: "Stats",
                newName: "Deaths");

            migrationBuilder.RenameColumn(
                name: "FIPS",
                table: "Stats",
                newName: "CountryRegion");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Stats",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

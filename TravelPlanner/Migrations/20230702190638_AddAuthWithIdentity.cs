using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelPlanner.Migrations
{
    public partial class AddAuthWithIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarRental",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Flight",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Hotel",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Itineraries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CarRental",
                table: "Itineraries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Flight",
                table: "Itineraries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Hotel",
                table: "Itineraries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Itineraries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DietineWebApp.Data.Migrations
{
    public partial class AddingPropstoPlannedFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CaloriePerOunce",
                table: "PlannedBreakfastFood",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PlannedBreakfastFood",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriePerOunce",
                table: "PlannedBreakfastFood");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PlannedBreakfastFood");
        }
    }
}

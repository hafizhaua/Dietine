using Microsoft.EntityFrameworkCore.Migrations;

namespace DietineWebApp.Data.Migrations
{
    public partial class PropsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "BreakfastFood",
                newName: "BFUserID");

            migrationBuilder.RenameColumn(
                name: "TotalCalorie",
                table: "BreakfastFood",
                newName: "BFTotalCalorie");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BreakfastFood",
                newName: "BFName");

            migrationBuilder.RenameColumn(
                name: "Gram",
                table: "BreakfastFood",
                newName: "BFGram");

            migrationBuilder.RenameColumn(
                name: "DbFoodID",
                table: "BreakfastFood",
                newName: "BFDbFoodID");

            migrationBuilder.RenameColumn(
                name: "CaloriePerOunce",
                table: "BreakfastFood",
                newName: "BFCaloriePerOunce");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BFUserID",
                table: "BreakfastFood",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "BFTotalCalorie",
                table: "BreakfastFood",
                newName: "TotalCalorie");

            migrationBuilder.RenameColumn(
                name: "BFName",
                table: "BreakfastFood",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BFGram",
                table: "BreakfastFood",
                newName: "Gram");

            migrationBuilder.RenameColumn(
                name: "BFDbFoodID",
                table: "BreakfastFood",
                newName: "DbFoodID");

            migrationBuilder.RenameColumn(
                name: "BFCaloriePerOunce",
                table: "BreakfastFood",
                newName: "CaloriePerOunce");
        }
    }
}

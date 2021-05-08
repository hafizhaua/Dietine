using Microsoft.EntityFrameworkCore.Migrations;

namespace DietineWebApp.Data.Migrations
{
    public partial class SchedulerChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlannedBreakfastFood");

            migrationBuilder.CreateTable(
                name: "BreakfastFood",
                columns: table => new
                {
                    BreakfastFoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaloriePerOunce = table.Column<double>(type: "float", nullable: false),
                    Gram = table.Column<double>(type: "float", nullable: false),
                    TotalCalorie = table.Column<double>(type: "float", nullable: false),
                    DbFoodID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastFood", x => x.BreakfastFoodID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastFood");

            migrationBuilder.CreateTable(
                name: "PlannedBreakfastFood",
                columns: table => new
                {
                    PlannedFoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaloriePerOunce = table.Column<double>(type: "float", nullable: false),
                    DbFoodID = table.Column<int>(type: "int", nullable: false),
                    Gram = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCalorie = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedBreakfastFood", x => x.PlannedFoodID);
                });
        }
    }
}

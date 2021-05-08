using Microsoft.EntityFrameworkCore.Migrations;

namespace DietineWebApp.Data.Migrations
{
    public partial class AddingBFPlannedFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlannedBreakfastFood",
                columns: table => new
                {
                    PlannedFoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gram = table.Column<double>(type: "float", nullable: false),
                    TotalCalorie = table.Column<double>(type: "float", nullable: false),
                    DbFoodID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedBreakfastFood", x => x.PlannedFoodID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlannedBreakfastFood");
        }
    }
}

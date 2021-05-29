using Microsoft.EntityFrameworkCore.Migrations;

namespace DietineWebApp.Data.Migrations
{
    public partial class AddingTakenActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Activity",
                newName: "ActivityName");

            migrationBuilder.RenameColumn(
                name: "CaloriePerMinute",
                table: "Activity",
                newName: "CalorieBurnedPerMinute");

            migrationBuilder.CreateTable(
                name: "TakenActivity",
                columns: table => new
                {
                    TakenActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TACalorieBurnedPerMinute = table.Column<double>(type: "float", nullable: false),
                    TAMinute = table.Column<double>(type: "float", nullable: false),
                    TATotalCaloriBurned = table.Column<double>(type: "float", nullable: false),
                    TADate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TADbID = table.Column<int>(type: "int", nullable: false),
                    TAUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenActivity", x => x.TakenActivityID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TakenActivity");

            migrationBuilder.RenameColumn(
                name: "CalorieBurnedPerMinute",
                table: "Activity",
                newName: "CaloriePerMinute");

            migrationBuilder.RenameColumn(
                name: "ActivityName",
                table: "Activity",
                newName: "Name");
        }
    }
}

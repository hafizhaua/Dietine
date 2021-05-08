using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DietineWebApp.Data.Migrations
{
    public partial class AddingFoodDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BFName",
                table: "BreakfastFood",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BFDate",
                table: "BreakfastFood",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DinnerFood",
                columns: table => new
                {
                    DinnerFoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DFCaloriePerOunce = table.Column<double>(type: "float", nullable: false),
                    DFGram = table.Column<double>(type: "float", nullable: false),
                    DFTotalCalorie = table.Column<double>(type: "float", nullable: false),
                    DFDbFoodID = table.Column<int>(type: "int", nullable: false),
                    DFUserID = table.Column<int>(type: "int", nullable: false),
                    DFDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerFood", x => x.DinnerFoodID);
                });

            migrationBuilder.CreateTable(
                name: "LunchFood",
                columns: table => new
                {
                    LunchFoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LFCaloriePerOunce = table.Column<double>(type: "float", nullable: false),
                    LFGram = table.Column<double>(type: "float", nullable: false),
                    LFTotalCalorie = table.Column<double>(type: "float", nullable: false),
                    LFDbFoodID = table.Column<int>(type: "int", nullable: false),
                    LFUserID = table.Column<int>(type: "int", nullable: false),
                    LFDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchFood", x => x.LunchFoodID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DinnerFood");

            migrationBuilder.DropTable(
                name: "LunchFood");

            migrationBuilder.DropColumn(
                name: "BFDate",
                table: "BreakfastFood");

            migrationBuilder.AlterColumn<string>(
                name: "BFName",
                table: "BreakfastFood",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

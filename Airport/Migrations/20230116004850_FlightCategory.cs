using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airport.Migrations
{
    public partial class FlightCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirlineID",
                table: "Flight",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlightCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FlightCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightCategory_Flight_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineID",
                table: "Flight",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCategory_CategoryID",
                table: "FlightCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCategory_FlightID",
                table: "FlightCategory",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airline_AirlineID",
                table: "Flight",
                column: "AirlineID",
                principalTable: "Airline",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airline_AirlineID",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropTable(
                name: "FlightCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Flight_AirlineID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "AirlineID",
                table: "Flight");
        }
    }
}

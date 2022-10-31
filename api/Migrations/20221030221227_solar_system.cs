using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class solar_system : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SolarSystemId",
                table: "Planets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SolarSystem",
                columns: table => new
                {
                    SolarSystemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystem", x => x.SolarSystemId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planets_SolarSystemId",
                table: "Planets",
                column: "SolarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_SolarSystem_SolarSystemId",
                table: "Planets",
                column: "SolarSystemId",
                principalTable: "SolarSystem",
                principalColumn: "SolarSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_SolarSystem_SolarSystemId",
                table: "Planets");

            migrationBuilder.DropTable(
                name: "SolarSystem");

            migrationBuilder.DropIndex(
                name: "IX_Planets_SolarSystemId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SolarSystemId",
                table: "Planets");
        }
    }
}

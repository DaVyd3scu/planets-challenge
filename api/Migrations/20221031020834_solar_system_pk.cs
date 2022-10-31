using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class solar_system_pk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_SolarSystem_SolarSystemId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Planets_PlanetId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Robots_RobotId",
                table: "Visit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visit",
                table: "Visit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolarSystem",
                table: "SolarSystem");

            migrationBuilder.RenameTable(
                name: "Visit",
                newName: "Visits");

            migrationBuilder.RenameTable(
                name: "SolarSystem",
                newName: "SolarSystems");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_RobotId",
                table: "Visits",
                newName: "IX_Visits_RobotId");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_PlanetId",
                table: "Visits",
                newName: "IX_Visits_PlanetId");

            migrationBuilder.RenameColumn(
                name: "SolarSystemId",
                table: "SolarSystems",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visits",
                table: "Visits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolarSystems",
                table: "SolarSystems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_SolarSystems_SolarSystemId",
                table: "Planets",
                column: "SolarSystemId",
                principalTable: "SolarSystems",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Planets_PlanetId",
                table: "Visits",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Robots_RobotId",
                table: "Visits",
                column: "RobotId",
                principalTable: "Robots",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_SolarSystems_SolarSystemId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Planets_PlanetId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Robots_RobotId",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visits",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolarSystems",
                table: "SolarSystems");

            migrationBuilder.RenameTable(
                name: "Visits",
                newName: "Visit");

            migrationBuilder.RenameTable(
                name: "SolarSystems",
                newName: "SolarSystem");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_RobotId",
                table: "Visit",
                newName: "IX_Visit_RobotId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_PlanetId",
                table: "Visit",
                newName: "IX_Visit_PlanetId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SolarSystem",
                newName: "SolarSystemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visit",
                table: "Visit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolarSystem",
                table: "SolarSystem",
                column: "SolarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_SolarSystem_SolarSystemId",
                table: "Planets",
                column: "SolarSystemId",
                principalTable: "SolarSystem",
                principalColumn: "SolarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Planets_PlanetId",
                table: "Visit",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Robots_RobotId",
                table: "Visit",
                column: "RobotId",
                principalTable: "Robots",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

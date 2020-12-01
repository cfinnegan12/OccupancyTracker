using Microsoft.EntityFrameworkCore.Migrations;

namespace OccupancyData.Migrations
{
    public partial class AddedBuildingtoSpace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Spaces",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_BuildingId",
                table: "Spaces",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spaces_Buildings_BuildingId",
                table: "Spaces",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spaces_Buildings_BuildingId",
                table: "Spaces");

            migrationBuilder.DropIndex(
                name: "IX_Spaces_BuildingId",
                table: "Spaces");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Spaces");
        }
    }
}

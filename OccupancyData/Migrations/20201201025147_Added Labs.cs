using Microsoft.EntityFrameworkCore.Migrations;

namespace OccupancyData.Migrations
{
    public partial class AddedLabs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lab",
                table: "Computers");

            migrationBuilder.AddColumn<int>(
                name: "LabId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_LabId",
                table: "Computers",
                column: "LabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Labs_LabId",
                table: "Computers",
                column: "LabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Labs_LabId",
                table: "Computers");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropIndex(
                name: "IX_Computers_LabId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "LabId",
                table: "Computers");

            migrationBuilder.AddColumn<int>(
                name: "Lab",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

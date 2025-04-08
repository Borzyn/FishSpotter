using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class idk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapModel_FishModel_FishModelName",
                table: "MapModel");

            migrationBuilder.DropIndex(
                name: "IX_MapModel_FishModelName",
                table: "MapModel");

            migrationBuilder.DropColumn(
                name: "FishModelName",
                table: "MapModel");

            migrationBuilder.DropColumn(
                name: "Fishes",
                table: "MapModel");

            migrationBuilder.DropColumn(
                name: "MapsNames",
                table: "FishModel");

            migrationBuilder.CreateTable(
                name: "FishModelMapModel",
                columns: table => new
                {
                    FishesName = table.Column<string>(type: "varchar(36)", nullable: false),
                    MapsName = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishModelMapModel", x => new { x.FishesName, x.MapsName });
                    table.ForeignKey(
                        name: "FK_FishModelMapModel_FishModel_FishesName",
                        column: x => x.FishesName,
                        principalTable: "FishModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FishModelMapModel_MapModel_MapsName",
                        column: x => x.MapsName,
                        principalTable: "MapModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FishModelMapModel_MapsName",
                table: "FishModelMapModel",
                column: "MapsName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FishModelMapModel");

            migrationBuilder.AddColumn<string>(
                name: "FishModelName",
                table: "MapModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fishes",
                table: "MapModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MapsNames",
                table: "FishModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MapModel_FishModelName",
                table: "MapModel",
                column: "FishModelName");

            migrationBuilder.AddForeignKey(
                name: "FK_MapModel_FishModel_FishModelName",
                table: "MapModel",
                column: "FishModelName",
                principalTable: "FishModel",
                principalColumn: "Name");
        }
    }
}

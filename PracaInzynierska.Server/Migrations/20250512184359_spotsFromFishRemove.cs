using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class spotsFromFishRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpotModel_FishModel_FishModelName",
                table: "SpotModel");

            migrationBuilder.DropIndex(
                name: "IX_SpotModel_FishModelName",
                table: "SpotModel");

            migrationBuilder.DropColumn(
                name: "FishModelName",
                table: "SpotModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FishModelName",
                table: "SpotModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpotModel_FishModelName",
                table: "SpotModel",
                column: "FishModelName");

            migrationBuilder.AddForeignKey(
                name: "FK_SpotModel_FishModel_FishModelName",
                table: "SpotModel",
                column: "FishModelName",
                principalTable: "FishModel",
                principalColumn: "Name");
        }
    }
}

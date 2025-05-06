using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class postAndSpot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "SpotModel");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "PostModel",
                type: "varchar(80)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "PostModel");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "SpotModel",
                type: "varchar(80)",
                nullable: false,
                defaultValue: "");
        }
    }
}

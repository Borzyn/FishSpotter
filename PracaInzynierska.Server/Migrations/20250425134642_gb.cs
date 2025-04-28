using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class gb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelId",
                table: "IngredientModel");

            migrationBuilder.DropIndex(
                name: "IX_IngredientModel_GroundbaitModelId",
                table: "IngredientModel");

            migrationBuilder.DropColumn(
                name: "GroundbaitModelId",
                table: "IngredientModel");

            migrationBuilder.AddColumn<string>(
                name: "GroundbaitModelGBName",
                table: "IngredientModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientModel_GroundbaitModelGBName",
                table: "IngredientModel",
                column: "GroundbaitModelGBName");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelGBName",
                table: "IngredientModel",
                column: "GroundbaitModelGBName",
                principalTable: "GroundbaitModel",
                principalColumn: "GBName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelGBName",
                table: "IngredientModel");

            migrationBuilder.DropIndex(
                name: "IX_IngredientModel_GroundbaitModelGBName",
                table: "IngredientModel");

            migrationBuilder.DropColumn(
                name: "GroundbaitModelGBName",
                table: "IngredientModel");

            migrationBuilder.AddColumn<string>(
                name: "GroundbaitModelId",
                table: "IngredientModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientModel_GroundbaitModelId",
                table: "IngredientModel",
                column: "GroundbaitModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelId",
                table: "IngredientModel",
                column: "GroundbaitModelId",
                principalTable: "GroundbaitModel",
                principalColumn: "GBName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

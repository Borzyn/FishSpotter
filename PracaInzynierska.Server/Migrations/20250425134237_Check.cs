using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class Check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodModel_GroundbaitModel_GroundbaitModelId",
                table: "MethodModel");

            migrationBuilder.RenameColumn(
                name: "GroundbaitModelId",
                table: "MethodModel",
                newName: "GroundbaitModelGBName");

            migrationBuilder.RenameIndex(
                name: "IX_MethodModel_GroundbaitModelId",
                table: "MethodModel",
                newName: "IX_MethodModel_GroundbaitModelGBName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GroundbaitModel",
                newName: "GBName");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodModel_GroundbaitModel_GroundbaitModelGBName",
                table: "MethodModel",
                column: "GroundbaitModelGBName",
                principalTable: "GroundbaitModel",
                principalColumn: "GBName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodModel_GroundbaitModel_GroundbaitModelGBName",
                table: "MethodModel");

            migrationBuilder.RenameColumn(
                name: "GroundbaitModelGBName",
                table: "MethodModel",
                newName: "GroundbaitModelId");

            migrationBuilder.RenameIndex(
                name: "IX_MethodModel_GroundbaitModelGBName",
                table: "MethodModel",
                newName: "IX_MethodModel_GroundbaitModelId");

            migrationBuilder.RenameColumn(
                name: "GBName",
                table: "GroundbaitModel",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodModel_GroundbaitModel_GroundbaitModelId",
                table: "MethodModel",
                column: "GroundbaitModelId",
                principalTable: "GroundbaitModel",
                principalColumn: "Id");
        }
    }
}

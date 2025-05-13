using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMethodFromGB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodModel_GroundbaitModel_GroundbaitModelGBName",
                table: "MethodModel");

            migrationBuilder.DropIndex(
                name: "IX_MethodModel_GroundbaitModelGBName",
                table: "MethodModel");

            migrationBuilder.DropColumn(
                name: "GroundbaitModelGBName",
                table: "MethodModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroundbaitModelGBName",
                table: "MethodModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MethodModel_GroundbaitModelGBName",
                table: "MethodModel",
                column: "GroundbaitModelGBName");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodModel_GroundbaitModel_GroundbaitModelGBName",
                table: "MethodModel",
                column: "GroundbaitModelGBName",
                principalTable: "GroundbaitModel",
                principalColumn: "GBName");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class minicorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelId",
                table: "IngredientModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_MethodModel_MethodName",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_MethodName",
                table: "PostModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MethodModel",
                table: "MethodModel");

            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "PostModel");

            migrationBuilder.AddColumn<string>(
                name: "MethodId",
                table: "PostModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "MethodModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BaitIds",
                table: "MethodModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "GroundBaitId",
                table: "MethodModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "GroundbaitModelId",
                table: "IngredientModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MethodModel",
                table: "MethodModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_MethodId",
                table: "PostModel",
                column: "MethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelId",
                table: "IngredientModel",
                column: "GroundbaitModelId",
                principalTable: "GroundbaitModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_MethodModel_MethodId",
                table: "PostModel",
                column: "MethodId",
                principalTable: "MethodModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelId",
                table: "IngredientModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_MethodModel_MethodId",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_MethodId",
                table: "PostModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MethodModel",
                table: "MethodModel");

            migrationBuilder.DropColumn(
                name: "MethodId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MethodModel");

            migrationBuilder.DropColumn(
                name: "BaitIds",
                table: "MethodModel");

            migrationBuilder.DropColumn(
                name: "GroundBaitId",
                table: "MethodModel");

            migrationBuilder.AddColumn<string>(
                name: "MethodName",
                table: "PostModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "GroundbaitModelId",
                table: "IngredientModel",
                type: "varchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MethodModel",
                table: "MethodModel",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_MethodName",
                table: "PostModel",
                column: "MethodName");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelId",
                table: "IngredientModel",
                column: "GroundbaitModelId",
                principalTable: "GroundbaitModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_MethodModel_MethodName",
                table: "PostModel",
                column: "MethodName",
                principalTable: "MethodModel",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

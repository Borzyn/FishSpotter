using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class checkin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_SpotModel_SpotId",
                table: "PostModel");

            migrationBuilder.RenameColumn(
                name: "SpotId",
                table: "PostModel",
                newName: "SpotID");

            migrationBuilder.RenameIndex(
                name: "IX_PostModel_SpotId",
                table: "PostModel",
                newName: "IX_PostModel_SpotID");

            migrationBuilder.AlterColumn<string>(
                name: "SpotID",
                table: "PostModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MethodName",
                table: "PostModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_SpotModel_SpotID",
                table: "PostModel",
                column: "SpotID",
                principalTable: "SpotModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_SpotModel_SpotID",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "PostModel");

            migrationBuilder.RenameColumn(
                name: "SpotID",
                table: "PostModel",
                newName: "SpotId");

            migrationBuilder.RenameIndex(
                name: "IX_PostModel_SpotID",
                table: "PostModel",
                newName: "IX_PostModel_SpotId");

            migrationBuilder.AlterColumn<string>(
                name: "SpotId",
                table: "PostModel",
                type: "varchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_SpotModel_SpotId",
                table: "PostModel",
                column: "SpotId",
                principalTable: "SpotModel",
                principalColumn: "Id");
        }
    }
}

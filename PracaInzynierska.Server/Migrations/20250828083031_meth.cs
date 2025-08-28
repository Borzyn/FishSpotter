using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class meth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MethodId",
                table: "PostModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MethodName",
                table: "PostModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MethodModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(36)", nullable: false),
                    BaitIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_MethodId",
                table: "PostModel",
                column: "MethodId");

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
                name: "FK_PostModel_MethodModel_MethodId",
                table: "PostModel");

            migrationBuilder.DropTable(
                name: "MethodModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_MethodId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "MethodId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "PostModel");
        }
    }
}

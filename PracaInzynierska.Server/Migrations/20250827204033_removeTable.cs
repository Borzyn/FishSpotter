using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class removeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_GroundbaitModel_groundbaitId",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_MethodModel_MethodId",
                table: "PostModel");

            migrationBuilder.DropTable(
                name: "IngredientModel");

            migrationBuilder.DropTable(
                name: "MethodModel");

            migrationBuilder.DropTable(
                name: "GroundbaitModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_groundbaitId",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_MethodId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "MethodId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "groundbaitId",
                table: "PostModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "groundbaitId",
                table: "PostModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GroundbaitModel",
                columns: table => new
                {
                    GBName = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundbaitModel", x => x.GBName);
                });

            migrationBuilder.CreateTable(
                name: "MethodModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    BaitIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaitModelId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Name = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MethodModel_BaitModel_BaitModelId",
                        column: x => x.BaitModelId,
                        principalTable: "BaitModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    GroundbaitModelGBName = table.Column<string>(type: "varchar(36)", nullable: true),
                    Name = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelGBName",
                        column: x => x.GroundbaitModelGBName,
                        principalTable: "GroundbaitModel",
                        principalColumn: "GBName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_groundbaitId",
                table: "PostModel",
                column: "groundbaitId");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_MethodId",
                table: "PostModel",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientModel_GroundbaitModelGBName",
                table: "IngredientModel",
                column: "GroundbaitModelGBName");

            migrationBuilder.CreateIndex(
                name: "IX_MethodModel_BaitModelId",
                table: "MethodModel",
                column: "BaitModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_GroundbaitModel_groundbaitId",
                table: "PostModel",
                column: "groundbaitId",
                principalTable: "GroundbaitModel",
                principalColumn: "GBName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_MethodModel_MethodId",
                table: "PostModel",
                column: "MethodId",
                principalTable: "MethodModel",
                principalColumn: "Id");
        }
    }
}

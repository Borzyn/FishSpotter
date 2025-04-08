using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class bedziegrubo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishModel_MethodModel_MethodModelName",
                table: "FishModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_FishModel_fishName",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpotModel_MapModel_MapName",
                table: "SpotModel");

            migrationBuilder.DropTable(
                name: "BaitModelMethodModel");

            migrationBuilder.DropTable(
                name: "GroundbaitModelMethodModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_fishName",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_FishModel_MethodModelName",
                table: "FishModel");

            migrationBuilder.DropColumn(
                name: "X",
                table: "SpotModel");

            migrationBuilder.DropColumn(
                name: "rate",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "X",
                table: "MapModel");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "MapModel");

            migrationBuilder.DropColumn(
                name: "MethodModelName",
                table: "FishModel");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "SpotModel",
                newName: "Map");

            migrationBuilder.RenameColumn(
                name: "MapName",
                table: "SpotModel",
                newName: "MapModelName");

            migrationBuilder.RenameIndex(
                name: "IX_SpotModel_MapName",
                table: "SpotModel",
                newName: "IX_SpotModel_MapModelName");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "PostModel",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "fishName",
                table: "PostModel",
                newName: "FishName");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "AccountModel",
                newName: "RateSum");

            migrationBuilder.AddColumn<string>(
                name: "XY",
                table: "SpotModel",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FishName",
                table: "PostModel",
                type: "varchar(24)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BaitId",
                table: "PostModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FishModelName",
                table: "PostModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MapName",
                table: "PostModel",
                type: "varchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MethodName",
                table: "PostModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpotId",
                table: "PostModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "groundbaitId",
                table: "PostModel",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "rateAmount",
                table: "PostModel",
                type: "varchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "rateSum",
                table: "PostModel",
                type: "varchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BaitModelId",
                table: "MethodModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroundbaitModelId",
                table: "MethodModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MapsNames",
                table: "FishModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "RateAmount",
                table: "AccountModel",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_BaitId",
                table: "PostModel",
                column: "BaitId");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_FishModelName",
                table: "PostModel",
                column: "FishModelName");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_groundbaitId",
                table: "PostModel",
                column: "groundbaitId");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_MethodName",
                table: "PostModel",
                column: "MethodName");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_SpotId",
                table: "PostModel",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodModel_BaitModelId",
                table: "MethodModel",
                column: "BaitModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodModel_GroundbaitModelId",
                table: "MethodModel",
                column: "GroundbaitModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodModel_BaitModel_BaitModelId",
                table: "MethodModel",
                column: "BaitModelId",
                principalTable: "BaitModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodModel_GroundbaitModel_GroundbaitModelId",
                table: "MethodModel",
                column: "GroundbaitModelId",
                principalTable: "GroundbaitModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_BaitModel_BaitId",
                table: "PostModel",
                column: "BaitId",
                principalTable: "BaitModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_FishModel_FishModelName",
                table: "PostModel",
                column: "FishModelName",
                principalTable: "FishModel",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_GroundbaitModel_groundbaitId",
                table: "PostModel",
                column: "groundbaitId",
                principalTable: "GroundbaitModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_MethodModel_MethodName",
                table: "PostModel",
                column: "MethodName",
                principalTable: "MethodModel",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_SpotModel_SpotId",
                table: "PostModel",
                column: "SpotId",
                principalTable: "SpotModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpotModel_MapModel_MapModelName",
                table: "SpotModel",
                column: "MapModelName",
                principalTable: "MapModel",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodModel_BaitModel_BaitModelId",
                table: "MethodModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MethodModel_GroundbaitModel_GroundbaitModelId",
                table: "MethodModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_BaitModel_BaitId",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_FishModel_FishModelName",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_GroundbaitModel_groundbaitId",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_MethodModel_MethodName",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_SpotModel_SpotId",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpotModel_MapModel_MapModelName",
                table: "SpotModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_BaitId",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_FishModelName",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_groundbaitId",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_MethodName",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_SpotId",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_MethodModel_BaitModelId",
                table: "MethodModel");

            migrationBuilder.DropIndex(
                name: "IX_MethodModel_GroundbaitModelId",
                table: "MethodModel");

            migrationBuilder.DropColumn(
                name: "XY",
                table: "SpotModel");

            migrationBuilder.DropColumn(
                name: "BaitId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "FishModelName",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "MapName",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "SpotId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "groundbaitId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "rateAmount",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "rateSum",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "BaitModelId",
                table: "MethodModel");

            migrationBuilder.DropColumn(
                name: "GroundbaitModelId",
                table: "MethodModel");

            migrationBuilder.DropColumn(
                name: "MapsNames",
                table: "FishModel");

            migrationBuilder.DropColumn(
                name: "RateAmount",
                table: "AccountModel");

            migrationBuilder.RenameColumn(
                name: "MapModelName",
                table: "SpotModel",
                newName: "MapName");

            migrationBuilder.RenameColumn(
                name: "Map",
                table: "SpotModel",
                newName: "Y");

            migrationBuilder.RenameIndex(
                name: "IX_SpotModel_MapModelName",
                table: "SpotModel",
                newName: "IX_SpotModel_MapName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PostModel",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "FishName",
                table: "PostModel",
                newName: "fishName");

            migrationBuilder.RenameColumn(
                name: "RateSum",
                table: "AccountModel",
                newName: "Score");

            migrationBuilder.AddColumn<string>(
                name: "X",
                table: "SpotModel",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "fishName",
                table: "PostModel",
                type: "varchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(24)");

            migrationBuilder.AddColumn<string>(
                name: "rate",
                table: "PostModel",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "X",
                table: "MapModel",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Y",
                table: "MapModel",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MethodModelName",
                table: "FishModel",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaitModelMethodModel",
                columns: table => new
                {
                    BaitId = table.Column<string>(type: "varchar(36)", nullable: false),
                    MethodsName = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaitModelMethodModel", x => new { x.BaitId, x.MethodsName });
                    table.ForeignKey(
                        name: "FK_BaitModelMethodModel_BaitModel_BaitId",
                        column: x => x.BaitId,
                        principalTable: "BaitModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaitModelMethodModel_MethodModel_MethodsName",
                        column: x => x.MethodsName,
                        principalTable: "MethodModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroundbaitModelMethodModel",
                columns: table => new
                {
                    GroundbaitId = table.Column<string>(type: "varchar(36)", nullable: false),
                    MethodsName = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundbaitModelMethodModel", x => new { x.GroundbaitId, x.MethodsName });
                    table.ForeignKey(
                        name: "FK_GroundbaitModelMethodModel_GroundbaitModel_GroundbaitId",
                        column: x => x.GroundbaitId,
                        principalTable: "GroundbaitModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroundbaitModelMethodModel_MethodModel_MethodsName",
                        column: x => x.MethodsName,
                        principalTable: "MethodModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_fishName",
                table: "PostModel",
                column: "fishName");

            migrationBuilder.CreateIndex(
                name: "IX_FishModel_MethodModelName",
                table: "FishModel",
                column: "MethodModelName");

            migrationBuilder.CreateIndex(
                name: "IX_BaitModelMethodModel_MethodsName",
                table: "BaitModelMethodModel",
                column: "MethodsName");

            migrationBuilder.CreateIndex(
                name: "IX_GroundbaitModelMethodModel_MethodsName",
                table: "GroundbaitModelMethodModel",
                column: "MethodsName");

            migrationBuilder.AddForeignKey(
                name: "FK_FishModel_MethodModel_MethodModelName",
                table: "FishModel",
                column: "MethodModelName",
                principalTable: "MethodModel",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_FishModel_fishName",
                table: "PostModel",
                column: "fishName",
                principalTable: "FishModel",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_SpotModel_MapModel_MapName",
                table: "SpotModel",
                column: "MapName",
                principalTable: "MapModel",
                principalColumn: "Name");
        }
    }
}
